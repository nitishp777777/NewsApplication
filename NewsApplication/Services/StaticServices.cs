using NewsApplication.API.Constants;
using NewsApplication.Models;
using Newtonsoft.Json;
using System.Net;

namespace NewsApplication.Services
{
    public class StaticServices
    {
        private string BASE_URL = "https://newsapi.org/v2/";
        private HttpClient _httpClient;
        private string ApiKey;

        public StaticServices(string apiKey)
        {

            ApiKey = apiKey;
            _httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate)

            });
            _httpClient.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
            _httpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
        }

        public async Task<ArticlesResult> GetTopHeadlinesAsync(TopHeadlinesRequest request)
        {
            List<string> queryParams = new List<string>();
            if (!string.IsNullOrEmpty(request.Q))
            {
                queryParams.Add("q=" + request.Q);
            }

            if(request.Sources.Count > 0)
            {
                queryParams.Add("sources=" + string.Join(",", request.Sources));
            }

            if (request.Category.HasValue)
            {
                queryParams.Add("category=" + request.Category.Value.ToString().ToLowerInvariant());
            }

            if (request.Language.HasValue)
            {
                queryParams.Add("language=" + request.Language.Value.ToString().ToLowerInvariant());
            }

            if (request.Country.HasValue)
            {
                queryParams.Add("country=" + request.Country.Value.ToString().ToLowerInvariant());
            }

            if (request.Page > 1)
            {
                queryParams.Add("page=" + request.Page);
            }

            if (request.PageSize > 0)
            {
                queryParams.Add("pageSize=" + request.PageSize);
            }

            string querystring = string.Join("&", queryParams.ToArray());
            return await MakeRequestfromWeb("top-headlines", querystring);
        }

        public ArticlesResult GetTopHealines(TopHeadlinesRequest request)
        {
            return GetTopHeadlinesAsync(request).Result;
        }

        public async Task<ArticlesResult> GetAllHeadlinesAsync(GetEverthingRequest request)
        {
            List<string> queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(request.Q))
            {
                queryParams.Add("q=" + request.Q);
            }

            if(request.Sources.Count > 0)
            {
                queryParams.Add("souces=" + string.Join(",", request.Sources));
            }

            if(request.Domains.Count > 0)
            {
                queryParams.Add("domains=" + string.Join(",", request.Sources));
            }

            if (request.From.HasValue)
            {
                queryParams.Add("from=" + $"{request.From.Value}");
            }

            if (request.To.HasValue)
            {
                queryParams.Add("to=" + $"{request.To.Value}");
            }

            if (request.Language.HasValue)
            {
                queryParams.Add("language=" + request.Language.Value.ToString().ToLowerInvariant());
            }

            if (request.SortBy.HasValue)
            {
                queryParams.Add("sortBy=" + request.SortBy.Value);
            }

            if(request.Page > 1)
            {
                queryParams.Add("page=" + request.Page);
            }

            if(request.PageSize > 0)
            {
                queryParams.Add("pageSize=" + request.PageSize);
            }

            string querystring = string.Join("&", queryParams.ToArray());
            return await MakeRequestfromWeb("everything", querystring);
        }

        public ArticlesResult GetEveryArticle(GetEverthingRequest request)
        {
            return GetAllHeadlinesAsync(request).Result;
        }

        private async Task<ArticlesResult> MakeRequestfromWeb(string endpoint,string querystring)
        {
            ArticlesResult articlesResult = new ArticlesResult();
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, BASE_URL + endpoint + "?" + querystring);
            string json = await ((await _httpClient.SendAsync(httpRequest)).Content.ReadAsStringAsync());

            if (!string.IsNullOrWhiteSpace(json))
            {
                NewAPIResponse apiResponse = JsonConvert.DeserializeObject<NewAPIResponse>(json);
                articlesResult.Statuses = apiResponse?.Status;
                if(articlesResult.Statuses == API.Constants.Statuses.Ok)
                {
                    articlesResult.TotalResults = apiResponse?.TotalResults;
                    articlesResult.Articles = apiResponse?.Articles;

                }
                else
                {
                    Errorcodes errorCodes = Errorcodes.UnknownError;
                    try
                    {
                        errorCodes = apiResponse.Code.Value;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("The API returned an error code that wasn't expected:" + apiResponse.Code.ToString);
                    }

                    articlesResult.Error = new Error
                    {
                        ErrorCodes = errorCodes,
                        Message = apiResponse.Message
                    };

                }
            }
            else
            {
                articlesResult.Statuses = Statuses.error;
                articlesResult.Error = new Error
                {
                    ErrorCodes = Errorcodes.UnexpectedError,
                    Message = "The API Returned an empty response."
                };
            }

            return articlesResult;
        }
    }
}
