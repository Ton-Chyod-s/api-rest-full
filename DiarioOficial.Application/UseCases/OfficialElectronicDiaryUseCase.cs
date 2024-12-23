using DiarioOficial.CrossCutting.DTOs;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases;
using OneOf;

namespace DiarioOficial.Application.UseCases
{
    internal class OfficialElectronicDiaryUseCase() : IOfficialElectronicDiaryUseCase
    {
        public async Task<OneOf<OfficialStateDiaryDTO, BaseError>> Execute(string cpf)
        {

            throw new NotImplementedException();    
        }
    }
}
