using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary;
using OneOf;

namespace DiarioOficial.Application.UseCases.OfficialElectronicDiary
{
    internal class OfficialElectronicDiaryUseCase() : IOfficialElectronicDiaryUseCase
    {
        public async Task<OneOf<ResponseOfficialStateDiaryDTO, BaseError>> Execute(string cpf)
        {

            throw new NotImplementedException();
        }
    }
}
