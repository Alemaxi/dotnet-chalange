using TODOListDDD.domain.Entities;

namespace TODOListDDD.api.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
