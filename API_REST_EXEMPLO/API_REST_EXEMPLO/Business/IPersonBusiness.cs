using API_REST_EXEMPLO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(int Id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(int Id);
    }
}
