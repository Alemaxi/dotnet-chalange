using TODOListDDD.application.Interfaces;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.application
{
    public class UserAppService : IUserAppService
    {
        protected readonly IUserService _service;

        public UserAppService(IUserService service)
        {
            _service = service;
        }

        public User CreateUser(string email, string password, string name)
        {
            return _service.CreateUser(email, password, name);
        }

        public User ValidateCredentials(string email, string password)
        {
            return _service.ValidateCredentials(email, password);
        }
    }
}
