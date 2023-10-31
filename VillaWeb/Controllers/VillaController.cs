using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VillaWeb.Models;
using VillaWeb.Models.DTO;
using VillaWeb.Services.IServices;

namespace VillaWeb.Controllers
{
    public class VillaController : Controller
    {
        // create mapper and vila service to access service to call api and mapper to amp between models in dto
        private readonly IMapper mapper;
        private readonly IVillaService villaService;
        public VillaController(IMapper mapper, IVillaService villaService)
        {
            this.mapper = mapper;
            this.villaService = villaService;
        }
    
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaMDTO> list = new();
            var response = await villaService.GetAllAsync<APIResponse>();
            if (response != null&&response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaMDTO>>(Convert.ToString( response.Result));
            }
            return View(list);
        }
        
        public async Task< IActionResult> CreateVilla()
        {
            
             return View();
        }
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public async Task<ActionResult> CreateVilla(VillaMCreateDTO model)
        {

            if (ModelState.IsValid)
            {
               var response= await villaService.CreateAsync<APIResponse>(model);
                if (response!=null&& response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
               
            }
            return View(model);
        }
        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var response = await villaService.GetAsync<APIResponse>(villaId);
            if (response != null && response.IsSuccess)
            {
                VillaMDTO villaDto = JsonConvert.DeserializeObject<VillaMDTO>(Convert.ToString(response.Result));
                     return View(mapper.Map<VillaMUpdateDTO>(villaDto));
            }
           
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaMUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await villaService.UpdateAsync<APIResponse>(model);
                if (response!=null&&response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }

            }
            return View(model);
           
        }
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            //var response = await villaService.GetAsync<APIResponse>(Id);
            //if (response != null && response.IsSuccess)
            //{
            //    VillaMDTO villaDto = JsonConvert.DeserializeObject<VillaMDTO>(Convert.ToString(response.Result));
            //    return View(mapper.Map<VillaMDTO>(villaDto));
            //}

            //return NotFound();
            var respons = await villaService.GetAsync<APIResponse>(villaId);
            if (respons != null && respons.IsSuccess)
            {
                VillaMDTO dto = JsonConvert.DeserializeObject<VillaMDTO>(Convert.ToString(respons.Result));
                return View(dto);
            }
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> DeleteVilla(VillaMDTO model)
        {
            var respons = await villaService.DeleteAsync<APIResponse>(model.ID);
            if (respons != null && respons.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVilla));
            }
            return View(model);
        }
    }
}
