using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using API_REST_EXEMPLO.Model;
using API_REST_EXEMPLO.Model.Context;
using API_REST_EXEMPLO.Repository;

namespace API_REST_EXEMPLO.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImpl (IPersonRepository repository)
        {
            _repository = repository;
        }

        //Metodo para Inserir um registro
        public Person Create(Person person)
        {
            return _repository.Create(person);            
        }

        //Metodo para remover
        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        //Metodo para trazer todos os registros
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        //Metodo para recuperar um registro específico
        public Person FindById(int Id)
        {
            return _repository.FindById(Id);
        }

        //Metodo para atualizar a tabela
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

    }
}