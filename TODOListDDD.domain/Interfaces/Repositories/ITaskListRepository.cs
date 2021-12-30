using System;
using System.Collections.Generic;
using System.Text;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.domain.Interfaces.Repositories
{
    public interface ITaskListRepository : IRepository<TaskList>
    {
        public List<TaskList> FindByName(string name);
        public List<TaskList> FindByCategory(string category);
    }
}
