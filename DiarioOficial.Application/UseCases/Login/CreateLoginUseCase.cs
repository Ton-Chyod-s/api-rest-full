using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Login;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class CreateLoginUseCase
        (
            IUnitOfWork unitOfWork
        ) : ICreateLoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<bool, BaseError>> CreateLogin(ResquestAddOrUpdateLoginDTO content)
        {
            if (content.UserName is null || content is null)
                return new UserNotSaved();

            return await _unitOfWork.UserRepository.AddUser(content);

        }

    }
}
