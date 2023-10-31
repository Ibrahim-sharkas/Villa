using Microsoft.AspNetCore.Mvc.Rendering;
using VillaWeb.Models.DTO;

namespace VillaWeb.Models.ViewModels
{
    public class VillaNumberDeleteVM
    {
        public VillaNumberDto VillaNumberDto { get; set; }
        public IEnumerable<SelectListItem>   VillaList { get; set; }
        public VillaNumberDeleteVM()
        {
                VillaNumberDto = new VillaNumberDto();
        }

    }
}
