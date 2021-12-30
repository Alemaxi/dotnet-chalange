using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOListDDD.domain.Entities;

namespace TODOListDDD.application.Interfaces
{
    public interface IUserAppService
    {
        public User ValidateCredentials(string email, string password);
        public User CreateUser(string email, string password, string name);
    }
}
