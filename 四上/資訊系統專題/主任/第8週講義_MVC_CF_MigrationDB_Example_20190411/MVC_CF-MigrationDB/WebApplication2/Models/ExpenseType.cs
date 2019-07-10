﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ExpenseType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string expenseType { get; set; }
    }
}