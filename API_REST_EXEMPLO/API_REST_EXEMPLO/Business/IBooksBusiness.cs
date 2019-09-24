using API_REST_EXEMPLO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books book);
        Books Update(Books book);
        void Delete(int Id);
        Books FindById(int Id);
        List<Books> FindAll();

    }
}
