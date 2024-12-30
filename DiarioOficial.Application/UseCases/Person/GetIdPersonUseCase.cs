using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Person;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Entities.BaseEntity;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Person;
using OneOf;

namespace DiarioOficial.Application.UseCases.Person
{
    internal class GetIdPersonUseCase
        (
            IUnitOfWork unitOfWork
        ) : IGetIdPersonUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<long?, BaseError>> GetIdPerson(string name)
        {
            var sizeName = name.EnsureValidName();

            var getIdPerson = await _unitOfWork.PersonRepository.GetIdPerson(name.TextToTitleCase());

            if (getIdPerson == 0)
                return new PersonNotFound();
            
            return getIdPerson;
        }
    }
}

