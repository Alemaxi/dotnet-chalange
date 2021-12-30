using System.Collections.Generic;
using TODOListDDD.application.Interfaces;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.application
{
    public class TaskListAppService : ITaskListAppService
    {
        protected readonly ITaskListService _service;

        public TaskListAppService(ITaskListService service)
        {
            _service = service;
        }

        public TaskList Create(TaskList item)
        {
            return _service.Create(item);
        }

        public void Delete(long id)
        {
            _service.Delete(id);
        }

        public TaskList Edit(TaskList item)
        {
            return _service.Edit(item);
        }

        public List<TaskList> FindAll()
        {
            return _service.FindAll();
        }

        public List<TaskList> FindByCategory(string category)
        {
            return _service.FindByCategory(category);
        }

        public TaskList FindById(long id)
        {
            return _service.FindById(id);
        }

        public List<TaskList> FindByName(string name)
        {
            return _service.FindByName(name);
        }
    }
}
