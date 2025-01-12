using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Entities.User;
using OneOf;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByName(string name, string password);
        Task<OneOf<bool, BaseError>> AddOrUpdateUser(User user);
        Task<OneOf<bool, BaseError>> AddOrUpdateToken(string bearerToken, long userId);
    }
}
