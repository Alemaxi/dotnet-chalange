using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Repositories;
using TODOListDDD.Infra.Data.Config;
using TODOListDDD.Infra.Data.Context;

namespace TODOListDDD.Infra.Data.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        protected readonly ApplicationContext _context;

        public UserTaskRepository()
        {
            _context = new ApplicationContext(ContextConfig.GetOptions());

        }

        public void Completed(long id)
        {
            try
            {
                var userTask = _context.UserTasks.SingleOrDefault(item => item.Id == id);
                userTask.Completed = true;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public UserTask Create(UserTask item)
        {
            try
            {
                var result = _context.UserTasks.Add(item).Entity;
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
                var delete = _context.UserTasks.SingleOrDefault(item => item.Id == id);
                _context.UserTasks.Remove(delete);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserTask Edit(UserTask item)
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

        public List<UserTask> FindAll()
        {
            return _context.UserTasks.ToList();
        }

        public UserTask FindById(long id)
        {
            return _context.UserTasks.FirstOrDefault(item => item.Id == id);
        }
    }
}
