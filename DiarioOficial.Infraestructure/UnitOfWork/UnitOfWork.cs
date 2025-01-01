﻿using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Infraestructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace DiarioOficial.Infraestructure.UnitOfWork
{
    internal class UnitOfWork(OfficialDiaryDbContext context) : IUnitOfWork
    {
        private readonly OfficialDiaryDbContext _context = context;
        private bool disposed = false;

        #region [Repositories]
        public IPersonRepository PersonRepository { get; private set; } = new Repository.PersonRepository(context);
        public IOfficialStateDiaryRepository OfficialStateDiaryRepository { get; private set; } = new Repository.OfficialStateDiaryRepository(context);
        public ISessionRepository SessionRepository { get; private set; } = new Repository.SessionRepository(context);
        public IUserRepository UserRepository { get; private set; } = new Repository.UserRepository(context);
        public IAuthTokenRepository AuthTokenRepository { get; private set; } = new Repository.AuthTokenRepository(context);
        public ICreateOrUpdateLoginRepository CreateOrUpdateLoginRepository { get; private set; } = new Repository.CreateOrUpdateLoginRepository(context);
        #endregion

        #region [Methods]
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
                _context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    
    }
}
