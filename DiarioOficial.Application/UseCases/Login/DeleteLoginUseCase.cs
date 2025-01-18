using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class DeleteLoginUseCase
        (
            IUnitOfWork unitOfWork
        ) : IDeleteLoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<bool, BaseError>> DeleteUser(long userId)
        {
            var delete = await _unitOfWork.UserRepository.DeleteUser(userId);

            return true;
        }
    }
}
