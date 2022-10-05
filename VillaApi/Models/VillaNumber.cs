using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaApi.Models
{
    public class VillaNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNO { get; set; }

        public string SpecialDetails { get; set; }
        public DateTime CreatedDat { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
