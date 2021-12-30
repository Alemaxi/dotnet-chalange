using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Services.Base;

namespace TODOListDDD.domain.Interfaces.Services
{
    public interface IUserTaskService : IServiceBase<UserTask>
    {
        public void Completed(long id);
    }
}
