﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ParkyApi.Models.Trail;

namespace ParkyApi.Models.Dtos
{
    public class TrailDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Distance { get; set; }
      
        [Required]
        public DifficultyType Difficulty { get; set; }
        [Required]
        public int NationalParkId { get; set; }
        
        public NationalParkDto NationalPark { get; set; }
        [Required]
        public double Elevation { get; set; }
    }
}
