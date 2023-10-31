using System.ComponentModel.DataAnnotations;

namespace VillaWeb.Models.DTO
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNO { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
        public VillaMDTO Villa { get; set; } 
    }
}
