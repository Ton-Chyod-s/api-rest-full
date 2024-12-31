using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
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

        public async Task<OneOf<ResponseTokenDTO, BaseError>> AddOrUpdateLogin(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO)
        {

            throw new NotImplementedException();
        }

    }
}
