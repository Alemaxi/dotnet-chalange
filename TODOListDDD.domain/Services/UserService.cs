using System;
using System.Collections.Generic;
using System.Text;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Repositories;
using TODOListDDD.domain.Interfaces.Services;

namespace TODOListDDD.domain.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User CreateUser(string email, string password, string name)
        {
            return _repository.CreateUser(email, password, name);
        }

        public User ValidateCredentials(string email, string password)
        {
            return _repository.ValidateCredentials(email, password);
        }
    }
}
