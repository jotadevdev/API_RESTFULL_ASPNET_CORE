using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace API_REST_EXEMPLO.Data.VO
{
    [DataContract]
    public class PersonVO : ISupportsHyperMedia
    {
        [DataMember (Order = 1,Name = "Codigo")]
        public int? Id { get; set; }

        [DataMember(Order = 2, Name = "NomeCompleto")]
        public string FirstName { get; set; }

        [DataMember(Order = 3, Name = "Sobrenome")]
        public string LastName { get; set; }

        [DataMember(Order = 4, Name = "Endereco")]
        public string Address { get; set; }

        [DataMember(Order = 5, Name = "EstadoCivil")]
        public string Gender { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
