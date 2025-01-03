using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Person;
using DiarioOficial.Domain.Entities.Person;
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
                var newPerson = new Person(name, email, userId);
                await _context.Person.AddAsync(newPerson);
            } else
            {
                person.UpdatePerson(name, email);
                _context.Person.Update(person);
            }

            if (await _context.SaveChangesAsync() < 0)
                return new PersonNotSaved();

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
    }
}
