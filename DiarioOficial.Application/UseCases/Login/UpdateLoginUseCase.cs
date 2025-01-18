using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class UpdateLoginUseCase
        (
            IUnitOfWork unitOfWork
        ) : IUpdateLoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<bool, BaseError>> UpdateLogin(RequestUpdateLoginDTO requestUpdateLoginDTO)
        {
            var userType = requestUpdateLoginDTO.Type ?? UserEnum.User;
            return await _unitOfWork.UserRepository.UpdateUser(requestUpdateLoginDTO.Name, userType);
        }
    }
}
