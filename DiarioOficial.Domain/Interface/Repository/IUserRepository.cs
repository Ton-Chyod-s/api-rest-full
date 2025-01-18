using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Entities.User;
using OneOf;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByName(string name, string password);
        Task<OneOf<bool, BaseError>> AddOrUpdateToken(string bearerToken, long userId);
        Task<bool> AddUser(ResquestAddOrLoginDTO content);
        Task<OneOf<bool, BaseError>> UpdateUser(string name, UserEnum? type);
    }
}
