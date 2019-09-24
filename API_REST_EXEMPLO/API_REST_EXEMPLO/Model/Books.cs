using API_REST_EXEMPLO.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Model
{
    public class Books : BaseEntity
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
    }
}
