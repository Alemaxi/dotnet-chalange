using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.application.Interfaces
{
    public interface ITaskListAppService : IAppServiceBase<TaskList>
    {
        public List<TaskList> FindByName(string name);
        public List<TaskList> FindByCategory(string category);
    }
}
