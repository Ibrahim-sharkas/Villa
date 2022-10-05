using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VillaApi.Core.Contracts;
using VillaApi.Models;
using VillaApi.Models.DTO;

namespace VillaApi.Controllers
{
    [Route("api/[VillaNumber]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVillaNumRepository villaNumRepository;
        protected APIResponse _response;
        public VillaNumberController(IVillaNumRepository _villaNumRepository,IMapper _map)
        {
            mapper = _map;
            villaNumRepository = _villaNumRepository;
           this._response = new APIResponse();
        }
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async ActionResult<APIResponse> GetAllAsync()
        //{
        //    IEnumerable<VillaNumber> villaNumbers = await villaNumRepository.GetAllAsync();
        //    _response.Result= mapper.Map<List<VillaNumber>>(List<VillaNumberDto>())
        //}


        //public async ActionResult<APIResponse> CreateVillaNum(VillaNumberCreatedDTO createdDTO)
        //{
        //    try
        //    {
        //        if (createdDTO!=null)
        //        {
        //           VillaNumber villaNumber=mapper.Map<VillaNumber>(createdDTO); 
        //            await villaNumRepository.CreateAsync(villaNumber);  
        //            _response.Result=
        //            return 
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        return Ok(_response);
        //    }
        //}
    }
}
