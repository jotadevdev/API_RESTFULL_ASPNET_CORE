using System;
using System.Collections.Generic;
using System.Threading;
using API_REST_EXEMPLO.Model;

namespace API_REST_EXEMPLO.Services.Implementation
{
    public class PersonServiceImpl : IPersonService
    {
        private  volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);

            }
            return persons;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = GetImcrement(),
                FirstName = "Person " + i,
                LastName = "Last name" + i,
                Address = "Endereco " + i,
                Gender = "Male"
            };

        }

        private long GetImcrement()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long Id)
        {
            return new Person
            {
                Id = GetImcrement(),
                FirstName = "Jayson",
                LastName = "Rezende",
                Address = "Rua Paulino",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
