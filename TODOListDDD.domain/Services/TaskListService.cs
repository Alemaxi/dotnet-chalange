using System;
using System.Collections.Generic;
using System.Text;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Repositories;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.domain.Services
{
    public class TaskListService : ITaskListService
    {
        protected readonly ITaskListRepository _repository;

        public TaskListService(ITaskListRepository repository)
        {
            _repository = repository;
        }

        public TaskList Create(TaskList item)
        {
            return _repository.Create(item);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public TaskList Edit(TaskList item)
        {
            return _repository.Edit(item);
        }

        public List<TaskList> FindAll()
        {
            return _repository.FindAll();
        }

        public List<TaskList> FindByCategory(string category)
        {
            return _repository.FindByCategory(category);
        }

        public TaskList FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<TaskList> FindByName(string name)
        {
            return _repository.FindByName(name);
        }
    }
}
