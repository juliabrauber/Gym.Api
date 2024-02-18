using Business.Abstractions.Interfaces.EFRepository;
using Business.Abstractions.IO.User;
using Entities.Data;
using Entities.Entities;
using Infra.Storage.EF;
using Microsoft.EntityFrameworkCore;

namespace Infra.Storage.Repositories.EF
{
    public class UserEFRepository : IUserEFRepository
    {
        private readonly GymEFContext _context;
        protected readonly DbSet<UserEntity> DbSet;

        public UserEFRepository(GymEFContext context)
        {
            _context = context;
            DbSet = _context.Set<UserEntity>();

        }
        public IUnitOfWork UnitOfWork => _context;


        public async Task<UserAuthOutput> AuthenticateAsync(string username, string password)
        {
           var user = await _context.Users.Where(x => x.IdUser == 17).FirstOrDefaultAsync();

            if (user != null)
            {
                //var lojas = await _context.UserStores
                //                            .Include(i => i.Store)
                //                            .AsNoTracking()
                //                            .Where(x => x.IdUser == user.IdUser)
                //                            .Select(x => new UserStoreAuthOutput
                //                                                                { IdStore = x.IdStore,
                //                                                                    Name = x.Store.Name 
                //                                                                }).ToListAsync();

                return new UserAuthOutput { Nome = user.Name, Senha = "", Role = user.Role == 1 ? "manager" : "loja", userStores = null };
            }
            return new();

        }
        public async Task<UserEntity> SaveAsync(UserEntity userEntity)
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return userEntity;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity userEntity)
        {
            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
            return userEntity;
        }

        public async Task<UserEntity> GetByIdAsync(int? idUser)
        {
            return await _context.Users.Where(x => x.IdUser == idUser).FirstAsync();
        }

        public void Dispose() => _context.Dispose();

        public async Task DeleteAsync(UserEntity userEntity)
        {
            await Task.Run(() => _context.Users.Remove(userEntity));
        }

        public async Task<(IEnumerable<UserEntity>, int)> GetListAsync(UserFilter userFilter)
        {
            var query = _context.Users.AsQueryable();

            if (userFilter.IdUser.HasValue)
            {
                query = query.Where(s => s.IdUser == userFilter.IdUser.Value);
            }

            if (!string.IsNullOrEmpty(userFilter.Name))
            {
                query = query.Where(s => s.Name == userFilter.Name);
            }

            if (!string.IsNullOrEmpty(userFilter.Email))
            {
                query = query.Where(s => s.Email == userFilter.Email);
            }

            if (userFilter.Status.HasValue)
            {
                query = query.Where(s => s.Status == userFilter.Status.Value);
            }

            if (userFilter.DateRegister.HasValue)
            {
                query = query.Where(s => s.DateRegister == userFilter.DateRegister.Value);
            }

            if (!string.IsNullOrEmpty(userFilter.Password))
            {
                query = query.Where(s => s.Password == userFilter.Password);
            }

            if (userFilter.Role.HasValue)
            {
                query = query.Where(s => s.Role == userFilter.Role);
            }

            if (userFilter.PhoneNumber.HasValue)
            {
                query = query.Where(s => s.PhoneNumber == userFilter.PhoneNumber.Value);
            }


            //if (!string.IsNullOrEmpty(storeFilter.SortField))
            //{
            //    query = query.OrderBy($"{storeFilter.SortField} {storeFilter.SortOrder ?? "ASC"}");
            //}

            var totalRecords = await query.CountAsync();

            int page = userFilter.Page ?? 1;
            int pageSize = userFilter.PageSize ?? 10;
            int offset = (page - 1) * pageSize;

            var userList = await query.Skip(offset).Take(pageSize).ToListAsync();

            return (userList, totalRecords);
        }

    }
}
