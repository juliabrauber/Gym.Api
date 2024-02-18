using Business.Abstractions.IO.User;
using Entities.Entities;


namespace Business.Abstractions.Interfaces.EFRepository
{
    public interface IUserEFRepository : IBaseEFRepository<UserEntity>
    {
        Task<UserAuthOutput> AuthenticateAsync(string username, string password);
        Task<UserEntity> SaveAsync(UserEntity product);
        Task<UserEntity> UpdateAsync(UserEntity userEntity);
        Task<UserEntity> GetByIdAsync(int? idUser);
        Task DeleteAsync(UserEntity userEntity);
    }
}
