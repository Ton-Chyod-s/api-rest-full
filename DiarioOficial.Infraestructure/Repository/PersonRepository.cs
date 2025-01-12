using DiarioOficial.CrossCutting.DTOs.Person;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors.Person;
using DiarioOficial.CrossCutting.Errors.Session;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Entities.OfficialStateDiary;
using DiarioOficial.Domain.Entities.Person;
using DiarioOficial.Domain.Entities.Session;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace DiarioOficial.Infraestructure.Repository
{
    internal class PersonRepository(OfficialDiaryDbContext context) : BaseRepository<Person>(context), IPersonRepository
    {
        public async Task<OneOf<bool, BaseError>> AddOrUpdatePerson(string name, string email, long userId)
        {
            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Name.Contains(name));

            if (person is null)
            {
                person = new Person(name, email, userId);
                await _context.Person.AddAsync(person);
            } else
            {
                person.UpdatePerson(name, email);
                _context.Person.Update(person);
            }

            if (await _context.SaveChangesAsync() < 0)
                return new PersonNotSaved();

            return true;
        }

        public async Task<OneOf<long, BaseError>> AddSession(long personId, string year)
        {
            var session = await _context.Sessions
                .FirstOrDefaultAsync(s => s.PersonID == personId && s.Year == year);

            if (session is null)
            {
                session = new Session(personId, year);
                await _context.Sessions.AddAsync(session);

                if (await _context.SaveChangesAsync() > 0)
                    return session.Id;
            }

            if (await _context.SaveChangesAsync() < 0)
                return new SessionErrors();

            return session.Id;
        }

        public async Task<OneOf<bool, BaseError>> addOfficialDiary(List<Dictionary<string, string>> responseOfficialMunicipalDiaryDTO)
        {
            foreach (var item in responseOfficialMunicipalDiaryDTO)
            {
                var newOfficialDiary = new OfficialDiaries(
                    item["Number"],
                    item["Day"],
                    item["File"],
                    item["Description"],
                    int.Parse(item["SessionId"]),
                    int.Parse(item["PersonId"])
                    );
                await _context.OfficialDiaries.AddAsync(newOfficialDiary);
            }

            if (await _context.SaveChangesAsync() < 0)
                return new OfficialDiaryNotSaved();

            return true;
        }



        public async Task<OneOf<bool?, BaseError>> RemovePerson(long personId)
        {
            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Id == personId);

            if (person is null)
            {
                return new PersonNotDeleted();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ResponsePersonDTO> GetPersonDTOAsync(string name)
        {
            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Name.Contains(name.FirstCharToUpper()));

            if (person is null)
            {
                return new ResponsePersonDTO(0, string.Empty, string.Empty);
            }

            return new ResponsePersonDTO(person.Id, person.Name, person.Email);
        }
    }
}
