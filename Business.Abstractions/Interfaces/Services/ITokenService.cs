using Business.Abstractions.IO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserAuthOutput user);
        List<UserStoreAuthOutput> GetUserStoresFromToken(string token);
    }
}
