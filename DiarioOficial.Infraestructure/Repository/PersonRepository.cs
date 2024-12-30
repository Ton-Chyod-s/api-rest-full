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
        public async Task<OneOf<bool, BaseError>> AddOrUpdatePerson(string name, string email)
        {
            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Name.Contains(name));

            if (person is null || !person.Name.Contains(name))
            {
                var newPerson = new Person(name, email);
                await _context.Person.AddAsync(newPerson);
            } else
            {
                person.UpdatePerson(name, email);
                _context.Person.Update(person);
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<long?> GetIdPerson(string name)
        {
            return await _context.Person
                .Where(p => p.Name.Contains(name))
                .Select(p => p.Id)   
                .FirstOrDefaultAsync();
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
