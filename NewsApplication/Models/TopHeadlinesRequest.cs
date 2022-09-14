using NewsAPI.Constants;

namespace NewsApplication.Models
{
    public class TopHeadlinesRequest
    {
        public List<string> Sources = new List<string>();

        public string? Q { get; set; }

        public Categories? Category { get; set; }

        public Languages? Language { get; set; }

        public Countries? Country { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
