using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Entities.Person;
using OneOf;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<OneOf<bool, BaseError>> AddOrUpdatePerson(string name, string email);
        Task<long?> GetIdPerson(string name);
        Task<OneOf<bool?, BaseError>> RemovePerson(long personId);
    }
}
