﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Genre
    {
        [Key]
        public int IdGenre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
