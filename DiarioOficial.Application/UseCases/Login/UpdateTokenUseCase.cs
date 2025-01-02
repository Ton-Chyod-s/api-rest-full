using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class UpdateTokenUseCase
        (
            IUnitOfWork unitOfWork
        ) : IUpdateTokenUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<bool, BaseError>> UpdateToken(long authToken, string token)
        {
            var userNameByDb = await _unitOfWork.AuthTokenRepository.AddOrUpdateAuthToken(authToken, token);

            if (!userNameByDb)
                return new UnauthorizedAccess();

            return true;
        }

    }
}
