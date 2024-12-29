using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Person;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Person;
using OneOf;

namespace DiarioOficial.Application.UseCases.Person
{
    internal class PersonUseCase
        (
            IUnitOfWork unitOfWork
        ) : IPersonUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<bool, BaseError>> AddOrUpdatePerson(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                return new InvalidName();

            var sizeName = name.Split(" ").Length;

            if (sizeName < 2)
                return new PersonNotSavedName();

            var getOrAddPerson = await _unitOfWork.PersonRepository.AddOrUpdatePerson(name.TextToTitleCase());

            return true;
        }

    }
}
