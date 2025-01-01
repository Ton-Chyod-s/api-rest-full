using DiarioOficial.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace DiarioOficial.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        IOfficialStateDiaryRepository OfficialStateDiaryRepository { get; }
        ISessionRepository SessionRepository { get; }
        IUserRepository UserRepository { get; }
        IAuthTokenRepository AuthTokenRepository { get; }
        ICreateOrUpdateLoginRepository CreateOrUpdateLoginRepository { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
