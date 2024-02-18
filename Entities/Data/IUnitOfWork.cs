
namespace Entities.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        void Dispose();
        bool HasUnsavedChanges();
    }
}
