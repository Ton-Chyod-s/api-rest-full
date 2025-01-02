using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.Domain.Entities.Person;
using DiarioOficial.Domain.Entities.Token;
using DiarioOficial.Domain.Entities.User;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface IAuthTokenRepository : IBaseRepository<AuthToken>
    {
        Task<bool> AddOrUpdateAuthToken(long authToken, string token);
    }
}
