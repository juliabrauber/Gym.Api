using Business.Abstractions.Interfaces.DapperRepository.Common;
using Business.Abstractions.IO.User;
using Entities.Entities;

namespace Business.Abstractions.Interfaces.DapperRepository
{
    public interface IUserDapperRepository : IBaseDapperRepository<UserEntity>
    {
        Task<IEnumerable<UserEntity>> GetListAsync(UserFilter userFilter);
    }
}
