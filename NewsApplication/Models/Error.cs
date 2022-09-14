using NewsApplication.API.Constants;

namespace NewsApplication.Models
{
    public class Error
    {
        public Errorcodes ErrorCodes { get; set; }

        public string? Message { get;set; }
    }
}
