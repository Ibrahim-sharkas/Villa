﻿using System.ComponentModel.DataAnnotations;

namespace VillaWeb.Models.DTO
{
    public class VillaMDTO
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
        public string Details { get; set; }
        
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public int Occupancy { get; set; }// Occupancy or Occupency
        public int Sqft { get; set; }
    }
}
