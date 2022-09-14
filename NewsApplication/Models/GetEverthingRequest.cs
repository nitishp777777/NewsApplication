using NewsApplication.API.Constants;

namespace NewsApplication.Models
{
    public class GetEverthingRequest
    {
            public List<string> Sources = new List<string>();

            public List<string> Domains = new List<string>();

            public string Q { get; set; }

            public DateTime? From { get; set; }

            public DateTime? To { get; set; }

            public Langauges? Language { get; set; }

            public SortyBys? SortBy { get; set; }

            public int Page { get; set; }

            public int PageSize { get; set; }
        
    }
}
