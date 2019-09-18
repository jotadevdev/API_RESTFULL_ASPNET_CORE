using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using API_REST_EXEMPLO.Model;
using API_REST_EXEMPLO.Model.Context;

namespace API_REST_EXEMPLO.Repository.Implementation
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private SqlServerContext _context;

        public PersonRepositoryImpl(SqlServerContext context)
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

                return person;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        //Metodo para remover
        public void Delete(int Id)
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
        public Person FindById(int Id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
        }

        //Metodo para atualizar a tabela
        public Person Update(Person person)
        {
            try
            {

                if (!Exist(person.Id)) return null;

                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(int? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}