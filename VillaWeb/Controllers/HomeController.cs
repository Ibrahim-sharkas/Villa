using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using VillaWeb.Models;
using VillaWeb.Models.DTO;
using VillaWeb.Services.IServices;

namespace VillaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _service;    
        private readonly IMapper _mapper;
        public HomeController(IVillaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;   
        }

        public async Task<IActionResult> Index()
        {
            List<VillaMDTO> list = new();
            var response= await _service.GetAllAsync<APIResponse>();
            if (response!=null&&response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaMDTO>>(Convert.ToString(response.Result));
                
            }
            return View(list);
        }

        
    }
}