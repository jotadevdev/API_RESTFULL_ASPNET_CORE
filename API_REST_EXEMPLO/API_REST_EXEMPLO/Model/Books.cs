﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Model
{
    public class Books
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Price { get; set; }
        public DateTime Data { get; set; }
    }
}