using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.SaveAndNotify
{
    public interface ISaveAndNotifyUseCase
    {
        Task<OneOf<bool, BaseError>> SaveAndNotify();
    }
}
