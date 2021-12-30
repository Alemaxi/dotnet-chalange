using System.Collections.Generic;
using TODOListDDD.application.Interfaces;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.application
{
    public class UserTaskAppService : IUserTaskAppService
    {
        protected readonly IUserTaskService _service;

        public void Completed(long id)
        {
            _service.Completed(id);
        }

        public UserTask Create(UserTask item)
        {
            return _service.Create(item);
        }

        public void Delete(long id)
        {
            _service.Delete(id);
        }

        public UserTask Edit(UserTask item)
        {
            return _service.Edit(item);
        }

        public List<UserTask> FindAll()
        {
            return _service.FindAll();
        }

        public UserTask FindById(long id)
        {
            return _service.FindById(id);
        }
    }
}
