using Business.Abstractions.Interfaces.DapperRepository;
using Entities.Entities;
using Infra.Storage.Dapper.Common;
using Infra.Storage.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstractions.IO.User;
using Dapper;
using System.Data;

namespace Infra.Storage.Repositories.Dapper
{
    public class UserDapperRepository : BaseDapperRepository<GymDapperContext, UserEntity>, IUserDapperRepository
    {
        public UserDapperRepository(GymDapperContext session) : base(session)
        {
        }

        public async Task<IEnumerable<UserEntity>> GetListAsync(UserFilter userFilter)
        {
            var query = new StringBuilder(@"SELECT * FROM Users WHERE 1 = 1");
            var parameters = new DynamicParameters();

            if (userFilter.IdUser != null)
            {
                query.Append(" AND IdUser = @IdUser");
                parameters.Add("IdUser", userFilter.IdUser.Value, DbType.Int32);
            }
            if (!string.IsNullOrEmpty(userFilter.Name))
            {
                query.Append(" AND Name = @Name");
                parameters.Add("Name", userFilter.Name, DbType.String);
            }
            if (!string.IsNullOrEmpty(userFilter.Email))
            {
                query.Append(" AND Email = @Email");
                parameters.Add("Email", userFilter.Email, DbType.String);
            }
            if (!string.IsNullOrEmpty(userFilter.Password))
            {
                query.Append(" AND Password = @Password");
                parameters.Add("Password", userFilter.Password, DbType.String);
            }
            if (userFilter.Role != null)
            {
                query.Append(" AND Role = @Role");
                parameters.Add("Role", userFilter.Role.Value, DbType.Int32);
            }
            if (userFilter.PhoneNumber != null)
            {
                query.Append(" AND PhoneNumber = @PhoneNumber");
                parameters.Add("PhoneNumber", userFilter.PhoneNumber.Value, DbType.Int64);
            }
            if (userFilter.Status != null)
            {
                query.Append(" AND Status = @Status");
                parameters.Add("Status", userFilter.Status.Value, DbType.Boolean);
            }
            if (userFilter.DateRegister != null)
            {
                query.Append(" AND DateRegister = @DateRegister");
                parameters.Add("DateRegister", userFilter.DateRegister.Value, DbType.DateTime);
            }

            var userList = await _session.Connection.QueryAsync<UserEntity>(query.ToString(), parameters, transaction: _session.Transaction);
            return userList;
        }
    }
}
