using DiarioOficial.CrossCutting.Enums.Person;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Person
{
    public interface IPersonUseCase
    {
        Task<OneOf<bool, BaseError>> AddOrUpdatePerson(PersonEnum personEnum);
    }
}
