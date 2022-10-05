using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VillaApi.Core.Contracts;
using VillaApi.Data;
using VillaApi.Models;
using VillaApi.Models.DTO;

namespace VillaApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        //  private readonly ApplicationContext _context;
        protected APIResponse _response;
        private readonly IVillaRepository _context;
        private readonly IMapper _mapper;
        public VillaAPIController(IVillaRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {


                IEnumerable<VillaM> villaMs = await _context.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDTO>>(villaMs);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMsgs = new List<string> { ex.Message };

            }
            return Ok(_response);
            //return Ok(_mapper.Map<List< VillaDTO>>(villaMs));      
        }
        [HttpGet("{id:int}", Name = "GetVilla")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(200,Type =typeof(VillaDTO)]
        public async Task<ActionResult<APIResponse>> GetVillaAsync(int id)
        {
            try
            {


                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _context.GetAsync(i => i.ID == id);
                if (villa == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMsgs = new List<string> { ex.Message };

            }
            return Ok(_response);
            // return Ok(_mapper.Map<VillaDTO>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateVillaAsync([FromBody] VillaCreateDto createVillaDTO)
        {
            try
            {


                if (await _context.GetAsync(i => i.Name.ToLower() == createVillaDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Name", "The name is already exists");
                    return BadRequest(ModelState);
                }
                if (createVillaDTO == null)
                {
                    return BadRequest(createVillaDTO);
                }
                //if (villaDTO.ID>0)
                //{
                //    return StatusCode(StatusCodes.Status500InternalServerError);
                //}

                // this create villa model and map the props to to created villacreateddto and assign the value to villa model from villacreateddto
                VillaM v = _mapper.Map<VillaM>(createVillaDTO);


                //VillaM v= new VillaM();
                //v.Name = createVillaDTO.Name;
                //v.Amenity= createVillaDTO.Amenity;
                //v.Sqft= createVillaDTO.Sqft;
                //v.Rate = createVillaDTO.Rate;
                //v.Details = createVillaDTO.Details;
                //v.CreatedAt = DateTime.Now;
                //v.ImageUrl = createVillaDTO.ImageUrl;
                //v.Occupancy = createVillaDTO.Occupency;
                await _context.CreateAsync(v);

                _response.Result = _mapper.Map<VillaDTO>(v);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = v.ID }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMsgs = new List<string> { ex.Message };

            }
            return Ok(_response);

        }
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> DeleteVillaAsync(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _context.GetAsync(i => i.ID == id);
                if (villa == null)
                {
                    _response.StatusCode=HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _context.Remove(villa);

                // VillaStore.VillaDTOs.Remove(villa);
                //  return NoContent();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMsgs = new List<string> { ex.Message };

            }
            return Ok(_response);

        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaAsync(int id, [FromBody] VillaUpdateDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.ID)
            {
                _response.StatusCode=HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            //VillaDTO dTO = VillaStore.VillaDTOs.FirstOrDefault(i => i.ID == id);
            //dTO.Name = villaDTO.Name;
            //dTO.Occupency = villaDTO.Occupency;
            //dTO.Sqft = villaDTO.Sqft;

            // this update villa model and map the props to to created villaupdateddto and assign the value to villa model from villaupdateddto
            VillaM v = _mapper.Map<VillaM>(villaDTO);
            //VillaM v = await _context.Villas.FirstOrDefaultAsync(i => i.ID == id);

            //v.Name = villaDTO.Name;
            //v.Amenity = villaDTO.Amenity;
            //v.Sqft = villaDTO.Sqft;
            //v.Rate = villaDTO.Rate;
            //v.Details = villaDTO.Details;
            //v.CreatedAt = DateTime.Now;
            //v.ImageUrl = villaDTO.ImageUrl;
            //v.Occupancy = villaDTO.Occupency;
            await _context.Update(v);

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        // error check up patch does not apply to save 


        [HttpPatch("id", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVillaAsync(int id, JsonPatchDocument<VillaUpdateDTO> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _context.GetAsync(i => i.ID == id, tracked: false);
            VillaUpdateDTO v = _mapper.Map<VillaUpdateDTO>(villa);
            //VillaUpdateDTO v = new VillaUpdateDTO();
            //v.Name = villa.Name;
            //v.Amenity = villa.Amenity;
            //v.Sqft = villa.Sqft;
            //v.Rate = villa.Rate;
            //v.Details = villa.Details;
            //v.ID = id;
            //v.ImageUrl = villa.ImageUrl;
            //v.Occupency = villa.Occupancy;Repository

            if (villa == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(v, ModelState);
            VillaM model = _mapper.Map<VillaM>(v);
            await _context.Update(model);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }


    }
}
