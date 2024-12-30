using DiarioOficial.CrossCutting.Enums.Person;
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

        public async Task<OneOf<bool, BaseError>> AddOrUpdatePerson(PersonEnum personEnum)
        {
            if (string.IsNullOrWhiteSpace(personEnum.Name) || personEnum.Name.Length < 3)
                return new InvalidName();

            var sizeName = personEnum.Name.EnsureValidName();

            var getOrAddPerson = await _unitOfWork.PersonRepository.AddOrUpdatePerson(personEnum.Name.TextToTitleCase(), personEnum.Email.ToLower());

            return true;
        }

    }
}
