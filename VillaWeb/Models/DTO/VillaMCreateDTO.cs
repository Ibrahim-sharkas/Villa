﻿using System.ComponentModel.DataAnnotations;

namespace VillaWeb.Models.DTO
{
    public class VillaMCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public int Occupancy { get; set; }
        public int Sqft { get; set; }
    }
}
