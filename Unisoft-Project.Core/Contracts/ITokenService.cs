
using Unisoft_Project.Infrastructure.Data.Entities;

namespace Unisoft_Project.Core.Contracts
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);

    }
}
