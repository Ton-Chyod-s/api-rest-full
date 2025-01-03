using DiarioOficial.CrossCutting.DTOs.Login.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Entities.User;
using OneOf;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface ICreateOrUpdateLoginRepository : IBaseRepository<User>
    {
        Task<OneOf<bool, BaseError>> AddOrUpdateUser(CreateOrUpdateLoginDTO createOrUpdateLoginDTO);
    }
}