using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;

        public LoginController(ISecurityService securityService, IUserService userService)
        {
            _securityService = securityService;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetAccess([FromBody] UserDTO userDTO)
        {
            _userService.ValidateUserLogin(userDTO);
            var token = _securityService.GenerateToken(userDTO);

            return Ok(new { token });
        }

    }
}
