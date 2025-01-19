using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Login;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Person;
using Microsoft.AspNetCore.Http;
using OneOf;

namespace DiarioOficial.Application.UseCases.Person
{
    internal class UpdateAuthPersonUseCase
        (
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor
        ) : IUpdateAuthPersonUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<OneOf<bool, BaseError>> UpdateAuthPerson()
        {
            var userName = _httpContextAccessor.HttpContext.GetSystemIdentifierIdByContext();

            var userResult = await _unitOfWork.UserRepository.GetUserByName(userName);

            if (userResult is null)
                return new UserNotFound();

            return await _unitOfWork.PersonRepository.UpdateAuthorized(userResult.Id);
        }
    }
}
