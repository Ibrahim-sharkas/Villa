using Newtonsoft.Json;
using System.Text;
using VillaUtility;
using VillaWeb.Models;
using VillaWeb.Services.IServices;

namespace VillaWeb.Services
{
    public class BaseService : IBaseService
    {
        // intilaize the response model in ctor
        // the response model will be used in the sendasync methode to receive the response from the method
        public APIResponse responseModel { get; set; }
        //declar httpclient to call api through ihttpclientfactory interface that is already rigistered in DJ
        public IHttpClientFactory httpClient { get; set; }   


        public BaseService(IHttpClientFactory httpClientFactory)
        {

            this.responseModel = new APIResponse();
            this.httpClient = httpClientFactory; 
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                // declare client var to manage httpclient instance and creat new http client
                var client= httpClient.CreateClient("VillaAPI"); 
                // declare request httprequestmeassage obj and add headers to it using headers.add() 
                
                HttpRequestMessage message= new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                //add uri through the propety uri in httprequest meassage and assign it from apirequest class propety which is string url
                message.RequestUri= new Uri(apiRequest.ApiUrl);
                // check the request data  if its null or not cuz if its get request there is no data to sent
                // and assign httprequest message object content the data we want to send for post and put endpoint
                if (apiRequest.Data!=null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data)
                        , Encoding.UTF8, "application/json");
                }
                // check the type of the request if its get or post or put or delete and then assign it to the httprequestmessage method
                switch (apiRequest.ApiType)
                {
                    
                    case SD.ApiType.POST:
                        message.Method=HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method=HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method=HttpMethod.Delete;   
                        break;
                    default:
                        message.Method=HttpMethod.Get;  
                        break;
                }
                //declare httpresponsemessage obj and assign it to null so it  can be used again in result for other request
                HttpResponseMessage apiResponse = null;
                // assign the apiresponse obj to the result of clint send methode with the request obj
                apiResponse = await client.SendAsync(message);
                // declare var for the content of the api response
                var apiContent= await apiResponse.Content.ReadAsStringAsync();
                try
                {
                    APIResponse APIIResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if (apiResponse.StatusCode==System.Net.HttpStatusCode.BadRequest||apiResponse.StatusCode==System.Net.HttpStatusCode.NotFound)
                    {
                        APIIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        APIIResponse.IsSuccess = false;
                        var res= JsonConvert.SerializeObject(APIIResponse);
                        var returnObj = JsonConvert.DeserializeObject<T>(res);
                        return returnObj;
                    }
                }
                catch (Exception e)
                {
                    var excResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return excResponse;
                }
                //deserlize th content of the apiresponse
               
                // return the result of the deserlize content    
                var APIResponse=JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {

                var dto = new APIResponse
                {
                    ErrorMsgs=new List<string>() { Convert.ToString(ex.Message) }
                    ,IsSuccess=false
                };
                var res=JsonConvert.SerializeObject(dto);
                var APIResponse= JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
