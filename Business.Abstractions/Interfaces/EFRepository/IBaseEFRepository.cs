
using Entities.Data;


namespace Business.Abstractions.Interfaces.EFRepository
{
    public interface IBaseEFRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

}
