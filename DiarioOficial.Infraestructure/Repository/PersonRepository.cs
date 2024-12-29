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
        public async Task<OneOf<bool, BaseError>> AddOrUpdatePerson(string name)
        {
            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Name.Contains(name));

            if (person is null || !person.Name.Contains(name))
            {
                var newPerson = new Person(name);
                await _context.Person.AddAsync(newPerson);
            } else
            {
                person.UpdatePerson(name);
                _context.Person.Update(person);
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<long?> GetIdPerson(string name)
        {
            return await _context.Person
                .Where(p => p.Name == name)
                .Select(p => p.Id)   
                .FirstOrDefaultAsync();
        }

        public async Task<OneOf<bool, BaseError>> RemovePerson(string name, long personId)
        {
            var person = await _context.Person
                .FirstOrDefaultAsync(p => p.Name == name && p.Id == personId);

            if (person is null || !person.Name.Contains(name))
            {
                return new PersonNotDeleted();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
