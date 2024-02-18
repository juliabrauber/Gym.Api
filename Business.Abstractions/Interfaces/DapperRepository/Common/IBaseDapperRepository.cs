using Entities.Data;

namespace Business.Abstractions.Interfaces.DapperRepository.Common
{
    public interface IBaseDapperRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
    }
}
