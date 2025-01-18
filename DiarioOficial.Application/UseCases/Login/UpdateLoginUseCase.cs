using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.CrossCutting.Errors.Login;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.Services.Token;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Login;
using Microsoft.AspNetCore.Http;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class UpdateLoginUseCase
        (
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            ITokenService tokenService

        ) : IUpdateLoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<OneOf<ResponseTokenDTO, BaseError>> UpdateLogin(RequestUpdateLoginDTO requestUpdateLoginDTO)
        {
            var userName = _httpContextAccessor.HttpContext.GetSystemIdentifierIdByContext();

            var userType = requestUpdateLoginDTO.Type ?? UserEnum.User;
            var update = await _unitOfWork.UserRepository.UpdateUser(userName, requestUpdateLoginDTO);

            var userResult = await _unitOfWork.UserRepository.GetUserByName(requestUpdateLoginDTO.Name);

            if (userResult is null)
                return new UserNotFound();

            var token = _tokenService.GenerateToken(userResult);

            var desaralizeToken = DesaralizeToken(token);

            if (token is null)
                return new UnauthorizedAccess();

            var TokenResult = await _unitOfWork.UserRepository.AddOrUpdateToken(desaralizeToken, userResult.Id);

            return token;
        }

        internal string DesaralizeToken(ResponseTokenDTO responseTokenDTO)
        {
            return responseTokenDTO.Bearer;
        }
    }
}
