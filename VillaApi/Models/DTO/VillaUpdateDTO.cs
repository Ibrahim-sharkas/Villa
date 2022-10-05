using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VillaApi.Models.DTO
{
    public class VillaUpdateDTO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]

        public string ImageUrl { get; set; }
        [Required]

        public string Amenity { get; set; }
        [Required]

        public int Occupency { get; set; }
        public int Sqft { get; set; }
    }
}
