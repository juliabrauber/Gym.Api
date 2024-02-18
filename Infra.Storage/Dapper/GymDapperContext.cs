using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Storage.Dapper
{
    public class GymDapperContext : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }
        public GymDapperContext(IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";

            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            Connection?.Close();
            Connection?.Dispose();
        }
    }
}
