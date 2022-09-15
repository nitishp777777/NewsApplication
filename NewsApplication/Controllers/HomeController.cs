using Microsoft.AspNetCore.Mvc;
using NewsApplication.Models;
using NewsApplication.Services;
using NewsApplication.API.Constants;
using NewsApplication.ViewModel;

namespace NewsApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult IndexAsync()
        {
            string api_key = _config.GetValue<string>("api_key");
            ArticlesViewModel articles = new ArticlesViewModel();
            List<ArticlesViewModel> articlesViewModels = new List<ArticlesViewModel>();
            var newsAPIClient = new StaticServices(api_key);

            var response = newsAPIClient.GetAllHeadlinesAsync
                (new GetEverthingRequest
                {
                    Q = "Apple",
                     
                }).Result;

           

           if(response.Statuses == Statuses.Ok)
            {
                return View(response.Articles);
            }
           //if(response.Statuses == Statuses.error)  
                return View();

        }

        //public IActionResult ArticleView()
        //{

        //}
       
    }
}