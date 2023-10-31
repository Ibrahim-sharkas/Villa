using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VillaWeb.Models.DTO;

namespace VillaWeb.Models.ViewModels
{
    public class VillaNumberCreateVM
    {
        public VillaNumberCreatDto VillaNumber   { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; }
        public VillaNumberCreateVM()
        {
            VillaNumber = new VillaNumberCreatDto();
        }   
    }
}
