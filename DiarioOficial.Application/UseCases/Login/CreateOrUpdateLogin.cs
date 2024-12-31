using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Application.UseCases.Login
{
    internal class CreateOrUpdateLogin
    {
        public async Task<OneOf<ResponseTokenDTO, BaseError>> AddOrUpdateLogin(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO)
        {

            throw new NotImplementedException();
        }

    }
}
