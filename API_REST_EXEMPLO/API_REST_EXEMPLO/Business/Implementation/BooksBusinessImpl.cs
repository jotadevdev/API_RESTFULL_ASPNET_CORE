using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_REST_EXEMPLO.Model;
using API_REST_EXEMPLO.Repository.Generic;

namespace API_REST_EXEMPLO.Business.Implementation
{
    public class BooksBusinessImpl : IBooksBusiness
    {
        private readonly IRepository<Books> _repositoryBooks;

        public BooksBusinessImpl(IRepository<Books> repositoryBooks)
        {
            _repositoryBooks = repositoryBooks;
        }

        public Books Create(Books book)
        {
            return _repositoryBooks.Create(book);
        }

        public void Delete(int Id)
        {
            _repositoryBooks.Delete(Id);
        }

        public List<Books> FindAll()
        {
            return _repositoryBooks.FindAll();
        }

        public Books FindById(int Id)
        {
            return _repositoryBooks.FindById(Id);
        }

        public Books Update(Books book)
        {
            return _repositoryBooks.Update(book);
        }
    }
}
