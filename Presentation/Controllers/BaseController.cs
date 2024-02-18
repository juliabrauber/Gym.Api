using Business.Abstractions.IO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {

        protected bool UserIsManagerSession()
        {
            if (HttpContext.Request.Headers.TryGetValue("authorization", out var authHeaderValue))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var claims = tokenHandler.ReadJwtToken(authHeaderValue.ToString().Replace("Bearer ", "")).Claims;

                var userRoleClaim = claims.FirstOrDefault(c => c.Type == "role");

                if (userRoleClaim != null)
                {
                    var userRoleJson = userRoleClaim.Value;
                    return userRoleJson == "manager";
                }
                return false;
            }
            else
            {
                return false;
            }

            
        }
        protected IEnumerable<int>? IdsUserStoresSession()
        {
            var userStores = GetUserStoreSession();
            if (userStores != null)
            {
                return userStores.Select(x => x.IdStore);
            }
            else
            {
                return null;
            }
        }
        protected List<UserStoreAuthOutput>? GetUserStoreSession()
        {
            if(HttpContext.Request.Headers.TryGetValue("authorization", out var authHeaderValue))
            {
                var userStores = GetUserStoresFromToken(authHeaderValue);

                if (userStores != null && userStores.Any())
                {
                    return userStores;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private List<UserStoreAuthOutput>? GetUserStoresFromToken(StringValues token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = tokenHandler.ReadJwtToken(token.ToString().Replace("Bearer ", "")).Claims;

            var userStoresClaim = claims.FirstOrDefault(c => c.Type == "UserStores");

            if (userStoresClaim != null)
            {
                var userStoresJson = userStoresClaim.Value;
                var userStores = JsonConvert.DeserializeObject<List<UserStoreAuthOutput>>(userStoresJson);

                return userStores;
            }
            return null;
        }
    }
}
