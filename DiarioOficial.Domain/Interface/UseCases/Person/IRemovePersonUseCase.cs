using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Person
{
    public interface IRemovePersonUseCase
    {
        Task<OneOf<bool, BaseError>> RemovePerson(long id);
    }
}
