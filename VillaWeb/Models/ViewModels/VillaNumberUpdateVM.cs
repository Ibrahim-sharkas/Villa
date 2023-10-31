using Microsoft.AspNetCore.Mvc.Rendering;
using VillaWeb.Models.DTO;

namespace VillaWeb.Models.ViewModels
{
    public class VillaNumberUpdateVM
    {
        public VillaNumberUpdateDto  VillaNumberDto { get; set; }
        public IEnumerable<SelectListItem> Villas { get; set; }
        public VillaNumberUpdateVM()
        {
            VillaNumberDto=new VillaNumberUpdateDto();
        }
    }
}
