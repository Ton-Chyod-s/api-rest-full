using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Person
{
    public interface IUpdateAuthPersonUseCase
    {
        Task<OneOf<bool, BaseError>> UpdateAuthPerson();
    }
}
