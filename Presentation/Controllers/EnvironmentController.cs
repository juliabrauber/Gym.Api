using Business.Abstractions.IO.CoreResult;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("identity-customer/[controller]")]
    public class EnvironmentController : ControllerBase
    {
        private readonly IConfiguration _config;
        public EnvironmentController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { ambiente = _config["ambiente"] });
        }
    }
}
