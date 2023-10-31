using System.ComponentModel.DataAnnotations;

namespace VillaWeb.Models.DTO
{
    public class VillaNumberUpdateDto
    {
        [Required]
        public int VillaNO { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
