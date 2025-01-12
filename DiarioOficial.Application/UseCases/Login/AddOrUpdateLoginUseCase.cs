using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Login.CreateOrUpdateLogin;
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
    internal class AddOrUpdateLoginUseCase
    (
        IUnitOfWork unitOfWork,
        ITokenService tokenService
    ) : IAddOrUpdateLoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<OneOf<bool, BaseError>> AddOrUpdateLogin(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO)
        {
            var CheckUser = await GetOrCreateUser(resquestAddOrUpdateLoginDTO);

            var token = _tokenService.GenerateToken(CheckUser);

            if (token is null)
                return new UnauthorizedAccess();

            var addOrUpdateUser = await _unitOfWork.UserRepository.AddOrUpdateUser(CheckUser);

            if (addOrUpdateUser.IsError())
                return addOrUpdateUser.GetError();

            var UserId = await GetOrCreateUser(resquestAddOrUpdateLoginDTO);

            var addOrUpdateToken = await _unitOfWork.UserRepository.AddOrUpdateToken(DesaralizeToken(token), UserId.Id);    

            if (addOrUpdateToken.IsError())
                return addOrUpdateToken.GetError();

            return true;
        }

        internal string DesaralizeToken(ResponseTokenDTO responseTokenDTO)
        {
            return responseTokenDTO.Bearer;
        }

        internal async Task<User> GetOrCreateUser(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO)
        {
            var userNameByDb = await _unitOfWork.UserRepository.GetUserByName(resquestAddOrUpdateLoginDTO.UserName, resquestAddOrUpdateLoginDTO.PasswordHash);

            if (userNameByDb is null)
            {
                userNameByDb = new User
                    (
                        resquestAddOrUpdateLoginDTO.UserName,
                        resquestAddOrUpdateLoginDTO.PasswordHash,
                        null,
                        null
                    );
            }

            if (resquestAddOrUpdateLoginDTO.role != userNameByDb.Roles)
            {
                userNameByDb = new User
                    (
                        resquestAddOrUpdateLoginDTO.UserName,
                        resquestAddOrUpdateLoginDTO.PasswordHash,
                        null,
                        resquestAddOrUpdateLoginDTO.role
                    );
            }

            return userNameByDb;
        }

    }
}
