using System;
using System.Collections.Generic;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Repositories;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.domain.Services
{
    public class UserTaskService : IUserTaskService
    {
        protected readonly IUserTaskRepository _repository;

        public UserTaskService(IUserTaskRepository repository)
        {
            _repository = repository;
        }

        public void Completed(long id)
        {
            _repository.Completed(id);
        }

        public UserTask Create(UserTask item)
        {
            return _repository.Create(item);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public UserTask Edit(UserTask item)
        {
            return _repository.Edit(item);
        }

        public List<UserTask> FindAll()
        {
            return _repository.FindAll();
        }

        public UserTask FindById(long id)
        {
            return _repository.FindById(id);
        }
    }
}
