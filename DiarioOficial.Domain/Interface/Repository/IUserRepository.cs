using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Entities.User;
using OneOf;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByName(string name);
        Task<OneOf<bool, BaseError>> AddOrUpdateToken(string bearerToken, long userId);
        Task<OneOf<bool, BaseError>> AddUser(ResquestAddOrLoginDTO content);
        Task<OneOf<bool, BaseError>> UpdateUser(string name, RequestUpdateLoginDTO requestUpdateLoginDTO);
    }
}
