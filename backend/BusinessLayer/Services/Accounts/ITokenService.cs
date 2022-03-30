using Core.Entities;

namespace BusinessLayer.Services.Accounts
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}