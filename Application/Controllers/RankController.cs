using Application.Base;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : BaseController<Rank, RankDTO>
    {
        private readonly IRankService _service;
        public RankController(IRankService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GeneralRanking")]
        public async Task<IActionResult> GetGeneralRanking([FromQuery] int categoryId)
        {
            var ranking = await _service.GetGeneralRanking(categoryId);
            return Ok(ranking);
        }
    }
}