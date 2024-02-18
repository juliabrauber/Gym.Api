using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(UserAuthOutput user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var userStoresJson = user.userStores != null && user.userStores.Any()
                ? JsonConvert.SerializeObject(user.userStores.ToList())
                : "";

            var key = Encoding.ASCII.GetBytes("7ae1f23c-eda1-434d-ae8d-1282240b22fc");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Nome.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("UserStores", userStoresJson)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public List<UserStoreAuthOutput> GetUserStoresFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = tokenHandler.ReadJwtToken(token).Claims;

            var userStoresClaim = claims.FirstOrDefault(c => c.Type == "UserStores");

            if (userStoresClaim != null)
            {
                var userStoresJson = userStoresClaim.Value;
                var userStores = JsonConvert.DeserializeObject<List<UserStoreAuthOutput>>(userStoresJson);

                return userStores;
            }

            // O token não contém um claim "UserStores"
            return new();
        }
    }
}
