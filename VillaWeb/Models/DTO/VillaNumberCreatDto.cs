using System.ComponentModel.DataAnnotations;

namespace VillaWeb.Models.DTO
{
    public class VillaNumberCreatDto
    {
        [Required]
        public int VillaNO { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
