﻿using API_REST_EXEMPLO.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Model
{
    public class Person: BaseEntity
    {
        //public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
