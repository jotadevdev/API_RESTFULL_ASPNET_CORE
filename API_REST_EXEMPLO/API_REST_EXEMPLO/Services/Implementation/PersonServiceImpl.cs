using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using API_REST_EXEMPLO.Model;
using API_REST_EXEMPLO.Model.Context;

namespace API_REST_EXEMPLO.Services.Implementation
{
    public class PersonServiceImpl : IPersonService
    {
        private SqlServerContext _context;

        public PersonServiceImpl (SqlServerContext context)
        {
            _context = context;
        }

        //Metodo para Inserir um registro
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        //Metodo para remover
        public void Delete(long Id)
        {
            try
            {
                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));

                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Metodo para trazer todos os registros
        public List<Person> FindAll()
        {

            return _context.Persons.ToList();

        }

        //Metodo para recuperar um registro específico
        public Person FindById(long Id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
        }

        //Metodo para atualizar a tabela
        public Person Update(Person person)
        {
            try
            {

                if (!Exist(person.Id)) return new Person();

                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}