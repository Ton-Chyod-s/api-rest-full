using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Person;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.Person;
using OneOf;

namespace DiarioOficial.Application.UseCases.Person
{
    internal class RemovePersonUseCase
        (
            IUnitOfWork unitOfWork
        ) : IRemovePersonUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OneOf<bool, BaseError>> RemovePerson(long id)
        {
            var removePerson = await _unitOfWork.PersonRepository.RemovePerson(id);

            if (removePerson.IsError())
                return removePerson.GetError();

            return true;
        }

    }
}
