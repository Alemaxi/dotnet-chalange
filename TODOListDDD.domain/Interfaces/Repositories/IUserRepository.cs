using System;
using System.Collections.Generic;
using System.Text;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User ValidateCredentials(string email, string password);
        public User CreateUser(string email, string password, string name);
    }
}
