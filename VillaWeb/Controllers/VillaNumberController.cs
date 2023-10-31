using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.CompilerServices;
using VillaWeb.Models;
using VillaWeb.Models.DTO;
using VillaWeb.Models.ViewModels;
using VillaWeb.Services;
using VillaWeb.Services.IServices;

namespace VillaWeb.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberServices numberServices;
        private readonly IVillaService villaService;
        private readonly IMapper mapper;
        public VillaNumberController(IVillaNumberServices _numberServices,IMapper _mapper,IVillaService _villaService)
        {
            numberServices = _numberServices;
            villaService = _villaService;
            mapper = _mapper;  
        }

        public async Task <IActionResult> IndexVillaNumbers()
        {
            List<VillaNumberDto> list = new();
            var response = await numberServices.GetAllAsync<APIResponse>();
            if (response!=null&&response.IsSuccess)
            {
                list=JsonConvert.DeserializeObject<List<VillaNumberDto>>(Convert.ToString(response.Result));
                  
            }
            return View(list);
        }

        public async Task<ActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberVM = new();
            var response= await villaService.GetAllAsync<APIResponse>();
            if (response!=null&&response.IsSuccess)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaMDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                         Text = i.Name,
                         Value=i.ID.ToString()
                    });
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await numberServices.CreateVillaNum<APIResponse>(model.VillaNumber);
                if (response!=null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumbers));
                }
                else
                {
                    if (response.ErrorMsgs.Count>0)
                    {
                        ModelState.AddModelError("CustomError", response.ErrorMsgs.FirstOrDefault());
                    }
                }
            }
            var respons = await villaService.GetAllAsync<APIResponse>();
            if (respons!=null && respons.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaMDTO>>
                    (Convert.ToString(respons.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.ID.ToString()
                    });
            }
            return View(model);
            
        }
        public async Task<IActionResult> UpdateVillaNumber(int VillaNO)
        {
            var respons= await numberServices.GetTAsync<APIResponse>(VillaNO);
            VillaNumberUpdateVM vM= new VillaNumberUpdateVM();
            if (respons !=null &&respons.IsSuccess)
            {
                VillaNumberDto model= JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(respons.Result));
                vM.VillaNumberDto=mapper.Map<VillaNumberUpdateDto>(model);    
            }
            respons = await villaService.GetAllAsync<APIResponse>();
            if (respons!=null&& respons.IsSuccess)
            {
                vM.Villas = JsonConvert.DeserializeObject<List<VillaMDTO>>(Convert.ToString(respons.Result)).
                    Select(i=>new SelectListItem
                    {
                        Text=i.Name,Value=i.ID.ToString()
                    });
                return View(vM);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                var response = await numberServices.UpdateVillaNum<APIResponse>(updateVM.VillaNumberDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumbers));
                }
                else
                {
                    if (response.ErrorMsgs.Count > 0)
                    {
                        ModelState.AddModelError("CustomError", response.ErrorMsgs.FirstOrDefault());
                    }
                }
            }
            var respons = await villaService.GetAllAsync<APIResponse>();
            if (respons != null && respons.IsSuccess)
            {
                updateVM.Villas = JsonConvert.DeserializeObject<List<VillaMDTO>>
                    (Convert.ToString(respons.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.ID.ToString()
                    });
            }
            return View(updateVM);

        }
        public async Task<IActionResult> DeleteVillaNumber(int VillaNO)
        {
            var respons= await numberServices.GetTAsync<APIResponse>(VillaNO);
            VillaNumberDeleteVM vm = new VillaNumberDeleteVM();
            if (respons!=null&&respons.IsSuccess)
            {
                vm.VillaNumberDto = JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(respons.Result));
               
            }
            respons= await villaService.GetAllAsync<APIResponse>();
            if (respons!= null && respons.IsSuccess)
            {
                vm.VillaList = JsonConvert.DeserializeObject<List<VillaMDTO>>(Convert.ToString(respons.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.ID.ToString()
                });
                return View(vm);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM deleteVM)
        {
            var respons = await numberServices.DeleteVillaNum<APIResponse>(deleteVM.VillaNumberDto.VillaNO);
            if (respons !=null&& respons.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumbers));
            }
            else
            {
                if (respons.ErrorMsgs.Count > 0)
                {
                    ModelState.AddModelError("CustomError", respons.ErrorMsgs.FirstOrDefault());
                }
            }

            respons = await villaService.GetAllAsync<APIResponse>();
            if (respons != null && respons.IsSuccess)
            {
                deleteVM.VillaList = JsonConvert.DeserializeObject<List<VillaMDTO>>
                    (Convert.ToString(respons.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.ID.ToString()
                    });
            }
            return View(deleteVM);
        }
    }
}
