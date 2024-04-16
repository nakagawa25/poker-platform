using Application.Base;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : BaseController<Player, PlayerDTO>
    {
        public PlayerController(IPlayerService service) : base(service)
        {
        }
    }
}