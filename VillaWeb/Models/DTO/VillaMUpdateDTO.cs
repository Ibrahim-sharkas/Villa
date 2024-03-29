﻿using System.ComponentModel.DataAnnotations;

namespace VillaWeb.Models.DTO
{
    public class VillaMUpdateDTO
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]

        public string ImageUrl { get; set; }
       

        public string Amenity { get; set; }
        [Required]

        public int Occupancy { get; set; }
        public int Sqft { get; set; }

    }
}
