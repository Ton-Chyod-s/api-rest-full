using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Login;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using Microsoft.AspNetCore.Http;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class DeleteLoginUseCase
        (
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor
        ) : IDeleteLoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<OneOf<bool, BaseError>> DeleteUser()
        {
            var userName = _httpContextAccessor.HttpContext.GetSystemIdentifierIdByContext();

            var User = await _unitOfWork.UserRepository.GetUserByName(userName);

            if (User is null)
                return new UserNotFound();

            var delete = await _unitOfWork.UserRepository.DeleteUser(User.Id);

            return true;
        }
    }
}
