using DiarioOficial.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace DiarioOficial.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        IOfficialStateDiaryRepository OfficialStateDiaryRepository { get; }
        ISessionRepository ISessionRepository { get; }
        IUserRepository IUserRepository { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
