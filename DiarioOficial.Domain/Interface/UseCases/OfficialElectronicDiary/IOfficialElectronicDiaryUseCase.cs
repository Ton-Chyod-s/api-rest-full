using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary
{
    public interface IOfficialElectronicDiaryUseCase
    {
        Task<OneOf<ResponseOfficialStateDiaryDTO, BaseError>> Execute(string cpf);
    }
}
