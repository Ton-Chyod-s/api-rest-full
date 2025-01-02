using System.Data;
using DiarioOficial.CrossCutting.DTOs.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Services.Token;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class CreateOrUpdateLoginUseCase
    (
        IUnitOfWork unitOfWork,
        ITokenService tokenService
    ) : ICreateOrUpdateLoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<OneOf<bool, BaseError>> AddOrUpdateLogin(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO)
        {
            var userNameByDb = await _unitOfWork.UserRepository.GetUserByName(resquestAddOrUpdateLoginDTO.UserName, resquestAddOrUpdateLoginDTO.PasswordHash);

            if (userNameByDb is null)
            {
                userNameByDb = new User
                    (
                        resquestAddOrUpdateLoginDTO.UserName,
                        resquestAddOrUpdateLoginDTO.PasswordHash,
                        resquestAddOrUpdateLoginDTO.Email,
                        true,
                        UserEnum.User
                    );
            }

            var token = _tokenService.GenerateToken(userNameByDb);

            if (token is null)
                return new UnauthorizedAccess();

            var createOrUpdateLogin = new CreateOrUpdateLoginDTO
            (
                resquestAddOrUpdateLoginDTO.UserName,
                resquestAddOrUpdateLoginDTO.PasswordHash,
                resquestAddOrUpdateLoginDTO.Email,
                true,
                null,
                DesaralizeToken(token)
            );

            var addOrUpdateUser = await _unitOfWork.CreateOrUpdateLoginRepository.AddOrUpdateUser(createOrUpdateLogin);

            if (addOrUpdateUser.IsError())
                return addOrUpdateUser.GetError();
            
            return true;
        }

        internal string DesaralizeToken(ResponseTokenDTO responseTokenDTO)
        {
            return responseTokenDTO.Bearer;
        }

    }
}
