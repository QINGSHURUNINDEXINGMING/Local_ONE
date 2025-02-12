﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GOOD
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string UID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int discount { get; set; }
        [Required]
        public int discount_price { get; set; }
    }
}