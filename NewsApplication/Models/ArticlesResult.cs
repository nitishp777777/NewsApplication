using NewsApplication.API.Constants;

namespace NewsApplication.Models
{
    public class ArticlesResult
    {
        public Statuses? Statuses { get; set; }

        public Error? Error { get; set; }

        public int? TotalResults { get; set; }

        public List<Articles>? Articles { get; set; }
    }
}
