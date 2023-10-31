using VillaWeb.Models;

namespace VillaWeb.Services.IServices
{
    public interface IBaseService
    {
        // declare prop for APIResponse
        public APIResponse  responseModel { get; set; }
        // declare method to send   task apirequest for the model we want the response of it
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
