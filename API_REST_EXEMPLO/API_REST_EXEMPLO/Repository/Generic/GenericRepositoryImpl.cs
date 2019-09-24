using API_REST_EXEMPLO.Model.Base;
using API_REST_EXEMPLO.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_REST_EXEMPLO.Repository.Generic
{
    public class GenericRepositoryImpl<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SqlServerContext _context;
        private DbSet<T> dataset;

        public GenericRepositoryImpl(SqlServerContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var result = dataset.SingleOrDefault(p => p.Id.Equals(Id));
                if (result != null) 
                    dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(int? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

        public T FindById(int Id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(Id));
        }

        public T Update(T item)
        {
            try
            {

                if (!Exist(item.Id)) return null;

                var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
