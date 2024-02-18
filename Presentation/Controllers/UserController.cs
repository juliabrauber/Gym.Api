using Business.Abstractions.Interfaces.Services;
using Business.Abstractions.IO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/")]
    public class UserController : BaseController
    {
        private IUserService _service;
        private ITokenService _tokenService;

        public UserController(IUserService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResult>> Authenticate([FromBody] AuthenticateInput model)
        {
            if (!string.IsNullOrEmpty(model.Login) && !string.IsNullOrEmpty(model.Password)) 
            {
                var user = await _service.AuthenticateAsync(model.Login, model.Password);

                if (user == null || string.IsNullOrEmpty(user.Nome))
                    return new AuthenticationResult { Success = false, Message = "Usuário ou senha inválidos" };

                var token = _tokenService.GenerateToken(user);

                user.Senha = "";

                if (token.Any())
                {
                    return Ok(new AuthenticationResult
                    {
                        Success = true,
                        Message = "Seja bem-vindo!",
                        User = user,
                        Token = token
                    });
                }
                else
                {
                    return BadRequest(new AuthenticationResult { Success = false, Message = "Usuário ou senha inválidos" });
                }
            } else
            {
                return BadRequest(new AuthenticationResult { Success = false, Message = "Usuário ou senha inválidos" });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UserInsertInput user)
        {
                return Ok(await _service.SaveAsync(user));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UserUpdateInput user)
        {
            return Ok(await _service.UpdateAsync(user));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

    }
}
