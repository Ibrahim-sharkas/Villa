using Microsoft.AspNetCore.Mvc;
using static VillaUtility.SD;

namespace VillaWeb.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }=ApiType.GET;
        public string ApiUrl { get; set; }
        public object Data { get;set; }
    }
}
