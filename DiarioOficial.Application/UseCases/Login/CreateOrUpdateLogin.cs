using DiarioOficial.CrossCutting.DTOs.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class CreateOrUpdateLogin
    (
        IUnitOfWork unitOfWork
    ) : IAddOrUpdateLogin
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<bool, BaseError>> AddOrUpdateLogin(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO)
        {
            var createOrUpdateLogin = new CreateOrUpdateLoginDTO
            (
                resquestAddOrUpdateLoginDTO.UserName,
                resquestAddOrUpdateLoginDTO.PasswordHash,
                resquestAddOrUpdateLoginDTO.Email,
                true,
                UserEnum.User,
                null
            );

            var addOrUpdateUser = await _unitOfWork.CreateOrUpdateLoginRepository.AddOrUpdateUser(createOrUpdateLogin);

            if (addOrUpdateUser.IsError())
                return addOrUpdateUser.GetError();
            
            return true;
        }

    }
}
