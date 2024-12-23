using DiarioOficial.CrossCutting.DTOs;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases;
using OneOf;

namespace DiarioOficial.Application.UseCases
{
    internal class OfficialStateDiary() : IOfficialStateDiary
    {
        public async Task<OneOf<OfficialStateDiaryDTO, BaseError>> Execute(string cpf)
        {

            // Implementation
            throw new NotImplementedException();    
        }
    }
}
