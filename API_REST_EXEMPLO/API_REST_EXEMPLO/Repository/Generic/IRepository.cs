using API_REST_EXEMPLO.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Repository.Generic
{
    public interface IRepository<T> where T: BaseEntity 
    {
        T Create(T item);
        T FindById(int Id);
        List<T> FindAll();
        T Update(T item);
        void Delete(int Id);

        bool Exist(int? id);
    }
}
