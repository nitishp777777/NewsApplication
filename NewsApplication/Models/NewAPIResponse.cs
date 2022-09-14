

using NewsApplication.API.Constants;

namespace NewsApplication.Models
{
    public class NewAPIResponse
    {
        public Statuses? Status { get; set; }

        public Errorcodes? Code { get; set; }

        public string? Message { get; set; }

        public List<Articles>? Articles { get; set; }

        public int TotalResults { get; set; }

    }
}
