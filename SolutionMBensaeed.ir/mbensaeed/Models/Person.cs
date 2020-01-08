﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mbensaeed.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]        
        public string Name { get; set; }
    }
}