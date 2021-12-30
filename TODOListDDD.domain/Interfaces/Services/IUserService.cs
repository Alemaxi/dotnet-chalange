using TODOListDDD.domain.Entities;

namespace TODOListDDD.domain.Interfaces.Services
{
    public interface IUserService
    {
        public User ValidateCredentials(string email, string password);
        public User CreateUser(string email, string password, string name);
    }
}
