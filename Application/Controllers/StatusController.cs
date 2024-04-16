using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult HealthStatus()
        {
            return Ok("Poker API is running.");
        }
    }
}
