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
    public class TaskListRepository : ITaskListRepository
    {
        protected readonly ApplicationContext _context;

        public TaskListRepository()
        {
            _context = new ApplicationContext(ContextConfig.GetOptions());
        }

        public TaskList Create(TaskList item)
        {
            try
            {
                var result = _context.TaskLists.Add(item).Entity;
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
                var delete = _context.TaskLists.FirstOrDefault(item => item.Id == id);
                if (delete == null) return;
                _context.TaskLists.Remove(delete);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TaskList Edit(TaskList item)
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

        public List<TaskList> FindAll()
        {
            return _context.TaskLists.Include(item => item.Category)
                .Include(item => item.UserTasks).ToList();
        }

        public List<TaskList> FindByCategory(string category)
        {
            return _context.TaskLists.Include(item => item.Category)
                .Include(item => item.UserTasks).Where(item => item.Category.Name == category).ToList();
        }

        public TaskList FindById(long id)
        {
            return _context.TaskLists.Include(item => item.Category)
                .Include(item => item.UserTasks).FirstOrDefault(item => item.Id == id);
        }

        public List<TaskList> FindByName(string name)
        {
            return _context.TaskLists.Include(item => item.Category)
                .Include(item => item.UserTasks).Where(item => item.Name == name).ToList();
        }
    }
}
