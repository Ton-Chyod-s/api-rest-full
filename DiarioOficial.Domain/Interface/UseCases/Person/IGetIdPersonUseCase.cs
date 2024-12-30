using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Person
{
    public interface IGetIdPersonUseCase
    {
        Task<OneOf<long?, BaseError>> GetIdPerson(string name);
    }
}
