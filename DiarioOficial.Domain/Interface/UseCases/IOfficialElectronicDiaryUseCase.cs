using DiarioOficial.CrossCutting.DTOs;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases
{
    public interface IOfficialElectronicDiaryUseCase
    {
        Task<OneOf<OfficialStateDiaryDTO, BaseError>> Execute(string cpf);
    }
}
