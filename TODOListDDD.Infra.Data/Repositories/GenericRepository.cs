using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TODOListDDD.domain.Entities.Base;
using TODOListDDD.domain.Interfaces.Repositories;
using TODOListDDD.Infra.Data.Config;
using TODOListDDD.Infra.Data.Context;

namespace TODOListDDD.Infra.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;
        protected DbSet<T> dataset;

        public GenericRepository()
        {
            _context = new ApplicationContext(ContextConfig.GetOptions());
            this.dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                var result = dataset.Add(item).Entity;
                _context.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Delete(long id)
        {
            try
            {
                var delete = dataset.FirstOrDefault(item => item.Id == id);
                dataset.Remove(delete);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Edit(T item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(item => item.Id == id);
        }
    }
}
