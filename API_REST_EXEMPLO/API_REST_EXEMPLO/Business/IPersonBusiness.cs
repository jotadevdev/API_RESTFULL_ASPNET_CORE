using API_REST_EXEMPLO.Data.VO;
using API_REST_EXEMPLO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO PersonVO);
        PersonVO FindById(int Id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO PersonVO);
        void Delete(int Id);
    }
}
