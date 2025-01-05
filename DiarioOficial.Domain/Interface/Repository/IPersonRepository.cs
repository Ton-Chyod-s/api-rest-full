using DiarioOficial.CrossCutting.DTOs.OfficialDiary;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.DTOs.Person;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Entities.Person;
using OneOf;

namespace DiarioOficial.Domain.Interface.Repository
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<OneOf<bool, BaseError>> AddOrUpdatePerson(string name, string email, long userId);
        Task<OneOf<bool?, BaseError>> RemovePerson(long personId);
        Task<ResponsePersonDTO> GetPersonDTOAsync(string name);
        Task<OneOf<bool, BaseError>> AddSession(long personId, string year);
        Task<OneOf<bool, BaseError>> addOfficialDiary(List<Dictionary<string, string>> responseOfficialMunicipalDiaryDTO));
    }
}
