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
    public class StageController : BaseController<Stage, StageDTO>
    {
        private readonly IStageService _stageService;

        public StageController(IStageService service) : base(service)
        {
            _stageService = service;
        }

        [AllowAnonymous]
        public override Task<IActionResult> GetbyId(int id)
        {
            return base.GetbyId(id);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] StageInsertDTO dto)
        {
            await _stageService.Create(dto);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] StageInsertDTO dto)
        {
            await _stageService.Update(dto);
            return Ok();
        }
    }
}