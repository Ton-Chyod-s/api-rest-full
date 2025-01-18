using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Login.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.CrossCutting.Errors.Login;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Entities.User;
using DiarioOficial.Domain.Interface.Services.Token;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class LoginUseCase
    (
        IUnitOfWork unitOfWork,
        ITokenService tokenService
    ) : ILoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<OneOf<ResponseTokenDTO, BaseError>> LoginWithApp(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO)
        {
            var userResult = await _unitOfWork.UserRepository.GetUserByName(resquestAddOrUpdateLoginDTO.UserName, resquestAddOrUpdateLoginDTO.Password);

            if (userResult is null)
                return new UserNotFound();

            var token = _tokenService.GenerateToken(userResult);

            var desaralizeToken = DesaralizeToken(token);

            if (token is null)
                return new UnauthorizedAccess();

            var TokenResult = await _unitOfWork.UserRepository.AddOrUpdateToken(desaralizeToken, userResult.Id);    

            if (TokenResult.IsError())
                return TokenResult.GetError();

            return token;
        }

        internal string DesaralizeToken(ResponseTokenDTO responseTokenDTO)
        {
            return responseTokenDTO.Bearer;
        }

    }
}
