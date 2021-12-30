using System;
using System.Collections.Generic;
using System.Text;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.domain.Interfaces.Repositories
{
    public interface IUserTaskRepository : IRepository<UserTask>
    {
        public void Completed(long id);
    }
}
