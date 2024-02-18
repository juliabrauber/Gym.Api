using Business.Abstractions.Interfaces.DapperRepository.Common;
using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Storage.Dapper.Common
{
    public abstract class BaseDapperRepository<IDbConnection, TEntity> : IBaseDapperRepository<TEntity> where TEntity : IAggregateRoot where IDbConnection : GymDapperContext
    {
        protected readonly IDbConnection _session;

        public BaseDapperRepository(IDbConnection session)
        {
            _session = session;
        }

        public void Dispose()
        {
            _session?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
