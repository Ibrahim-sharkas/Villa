﻿using System.ComponentModel.DataAnnotations;

namespace VillaApi.Models.DTO
{
    public class VillaNumberUpdatedDTO
    {
        [Required]
        public int VillaNO { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
