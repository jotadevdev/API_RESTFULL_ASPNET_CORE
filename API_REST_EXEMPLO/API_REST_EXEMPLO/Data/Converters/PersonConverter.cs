using API_REST_EXEMPLO.Data.Converter;
using API_REST_EXEMPLO.Data.VO;
using API_REST_EXEMPLO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_REST_EXEMPLO.Data.Converters
{
    public class PersonConverter : IParse<PersonVO, Person>, IParse<Person, PersonVO>
    {
        public Person Parse(PersonVO origem)
        {
            if (origem == null) return new Person();
            return new Person
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public PersonVO Parse(Person origem)
        {
            if (origem == null) return new PersonVO();
            return new PersonVO
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender
            };
        }

        public List<Person> PaserList(List<PersonVO> origem)
        {
            if (origem == null) return new List<Person>();
            return origem.Select(item => Parse(item)).ToList();

        }

        public List<PersonVO> PaserList(List<Person> origem)
        {
            if (origem == null) return new List<PersonVO>();
            return origem.Select(item => Parse(item)).ToList();

        }
    }
}
