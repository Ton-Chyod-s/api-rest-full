using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.Domain.Interface.Services.Token;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class GenerateTokenUseCase
        (
            ITokenService tokenService,
            IUnitOfWork unitOfWork
        ) : IGenerateTokenUseCase
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<ResponseTokenDTO, BaseError>> GenerateToken(RequestLoginDTO loginDTO)
        {
            var userNameByDb = await _unitOfWork.UserRepository.GetUserByName(loginDTO.Username, loginDTO.PasswordHash);

            var token = _tokenService.GenerateToken(userNameByDb);

            if (token is null)
                return new UnauthorizedAccess();
            
            return token;
        }
    }
}
