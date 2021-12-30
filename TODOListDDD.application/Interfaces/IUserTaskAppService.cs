using TODOListDDD.domain.Entities;

namespace TODOListDDD.application.Interfaces
{
    public interface IUserTaskAppService : IAppServiceBase<UserTask>
    {
        public void Completed(long id);
    }
}
