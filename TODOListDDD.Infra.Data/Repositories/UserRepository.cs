using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TODOListDDD.domain.Entities;
using TODOListDDD.domain.Interfaces.Repositories;
using TODOListDDD.Infra.Data.Config;
using TODOListDDD.Infra.Data.Context;

namespace TODOListDDD.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationContext _context;
        protected HMACSHA256 algoritmo;

        public UserRepository()
        {
            _context = new ApplicationContext(ContextConfig.GetOptions());
            algoritmo = new HMACSHA256();
        }

        public User CreateUser(string email, string password, string name)
        {
            try
            {
                var user = new User
                {
                    Email = email,
                    Password = ComputeHash(password,algoritmo),
                    Name = name,
                };

                var result = _context.Users.Add(user).Entity;

                _context.SaveChanges();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ValidateCredentials(string email, string password)
        {
            return _context.Users.SingleOrDefault(item =>
                (item.Email.Equals(email)) || (item.Password.Equals(ComputeHash(password,algoritmo))));
        }

        public string ComputeHash(string input , HMACSHA256 algorithm)
        {
            var encodedInput = Encoding.UTF8.GetBytes(input);
            var encripted = algorithm.ComputeHash(encodedInput);

            return BitConverter.ToString(encripted);
        }
    }
}
