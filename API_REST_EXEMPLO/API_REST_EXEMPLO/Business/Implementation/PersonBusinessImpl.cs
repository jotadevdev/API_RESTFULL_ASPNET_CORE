using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using API_REST_EXEMPLO.Data.Converters;
using API_REST_EXEMPLO.Data.VO;
using API_REST_EXEMPLO.Model;
using API_REST_EXEMPLO.Repository.Generic;

namespace API_REST_EXEMPLO.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IRepository<Person> _repository;

        private PersonConverter _Converter;

        public PersonBusinessImpl (IRepository<Person> repository)
        {
            _repository = repository;
            _Converter = new PersonConverter();
        }

        //Metodo para Inserir um registro
        public PersonVO Create(PersonVO PersonVO)
        {
            var person = _Converter.Parse(PersonVO);
            return _Converter.Parse(_repository.Create(person));            
        }

        //Metodo para remover
        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        //Metodo para trazer todos os registros
        public List<PersonVO> FindAll()
        {
            return _Converter.PaserList(_repository.FindAll());
        }

        //Metodo para recuperar um registro específico
        public PersonVO FindById(int Id)
        {
            return _Converter.Parse(_repository.FindById(Id));
        }

        //Metodo para atualizar a tabela
        public PersonVO Update(PersonVO PersonVO)
        {
            var person = _Converter.Parse(PersonVO);
            return _Converter.Parse(_repository.Update(person));
        }

    }
}