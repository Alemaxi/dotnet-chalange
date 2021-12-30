using System.Collections.Generic;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Services.Base;

namespace TODOListDDD.domain.Interfaces.Services
{
    public interface ITaskListService : IServiceBase<TaskList>
    {
        public List<TaskList> FindByName(string name);
        public List<TaskList> FindByCategory(string category);
    }
}
