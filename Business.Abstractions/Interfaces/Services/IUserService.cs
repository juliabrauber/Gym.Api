using Business.Abstractions.Interfaces.IO;
using Business.Abstractions.IO.CoreResult;
using Business.Abstractions.IO.User;

namespace Business.Abstractions.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserAuthOutput> AuthenticateAsync(string username, string password);
        Task<IResultOutput<UserOutput>> SaveAsync(UserInsertInput user);
        Task<IResultOutput<UserOutput>> UpdateAsync(UserUpdateInput user);
        Task<IResultOutput<UserOutput>> DeleteAsync(int id);
        Task<IResultOutput<UserOutput>> GetByIdAsync(int id);
    }
}
