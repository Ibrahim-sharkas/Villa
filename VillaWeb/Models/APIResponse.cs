using System.Net;

namespace VillaWeb.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMsgs { get; set; }
        public object Result { get; set; }
    }
}
