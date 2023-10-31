using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VillaApi.Core.Contracts;
using VillaApi.Models;
using VillaApi.Models.DTO;

namespace VillaApi.Controllers
{
    [Route("api/VillaNumber")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVillaNumRepository villaNumRepository;
        private readonly IVillaRepository villaRepository;
        protected APIResponse _response;
        public VillaNumberController(IVillaNumRepository _villaNumRepository,IMapper _map, IVillaRepository villaRepository)
        {
            mapper = _map;
            villaNumRepository = _villaNumRepository;
            this._response = new APIResponse();
            this.villaRepository = villaRepository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllAsync()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumbers = await villaNumRepository.GetAllAsync(includePropeties:"Villa");
                _response.Result = mapper.Map<List<VillaNumberDto>>(villaNumbers);
                return Ok(_response);
            } 
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMsgs = new List<string> { ex.Message };
            }
            return Ok(_response);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumAsync([FromBody] VillaNumberCreatedDTO villaNumberDto)
        {
            try
            {
                
                if (await villaRepository.GetAsync(i=>i.ID== villaNumberDto.VillaID) ==null)
                {
                    ModelState.AddModelError("ErrorMsgs", "the id is invalid");
                    return BadRequest(ModelState); 
                }
                if (await villaNumRepository.GetAsync(i=>i.VillaNO==villaNumberDto.VillaNO)!=null)
                {
                    ModelState.AddModelError("ErrorMsgs", "villa number is not valid");
                    return BadRequest(ModelState);
                }
                VillaNumber villaNumber=mapper.Map<VillaNumber>(villaNumberDto);    
                await villaNumRepository.CreateAsync(villaNumber);  
                _response.Result = mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode=HttpStatusCode.Created;
                return _response;
            }
            catch (Exception ex)
            {

                _response.ErrorMsgs=new List<string> { ex.Message };
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                
            }

            return _response;
        }
        [HttpGet("{no:int}",Name = "GetVillaNumAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVillaNumAsync(int no)
        {
            try
            {
                if (no==0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                            
                VillaNumber villaNumber = await villaNumRepository.GetAsync(i => i.VillaNO == no);

                _response.Result = mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok (_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess=false;
                _response.ErrorMsgs = new List<string>() { ex.ToString() };
                _response.StatusCode = HttpStatusCode.BadRequest;
                   
            }
            return _response;
        }
        [HttpDelete("{no:int}",Name="DeleteVillaNumAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumAsync(int no)
        {
            try
            {
                if (no==0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return _response;
                }
                VillaNumber villaNumber = await villaNumRepository.GetAsync(i => i.VillaNO == no);
                
                _response.Result=mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode=HttpStatusCode.OK; 
                await villaNumRepository.Remove(villaNumber);
                return Ok(_response);   
            }
            catch (Exception ex)
            {

                _response.ErrorMsgs=new List<string>() { ex.ToString() };
                _response.IsSuccess=false;
                _response.StatusCode= HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
        [HttpPut("{no:int}",Name ="UpdateVillaNumAsync")]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumAsync(int no, [FromBody] VillaNumberUpdatedDTO updatedDTO)
        {
            try
            {

                if (no==0)
                {
                    return BadRequest();
                }
                if (await villaRepository.GetAsync(i => i.ID == updatedDTO.VillaID) == null)
                {
                    ModelState.AddModelError("ErrorMsgs", "the id is invalid");
                    return BadRequest(ModelState);
                }
                if (updatedDTO==null)
                {
                    return BadRequest();
                }
                VillaNumber villaNumber =mapper.Map<VillaNumber>(updatedDTO);

                await villaNumRepository.Update(villaNumber);
                _response.Result = mapper.Map<VillaNumberDto>(villaNumber);
                _response.StatusCode=HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMsgs = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;    
                _response.StatusCode = HttpStatusCode.BadRequest;   
            }
            return _response;
        }


    }
}
