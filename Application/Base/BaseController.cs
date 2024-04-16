using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Base;

namespace Application.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<T, D> : ControllerBase where T : class where D : class
    {
        private readonly IBaseService<T, D> _baseService;

        public BaseController(IBaseService<T, D> service)
        {
            _baseService = service;
        }

        [HttpGet]
        [Route("all")]

        public async virtual Task<IActionResult> GetAll()
        {
            var result = await _baseService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetbyId(int id)
        {
            var result = await _baseService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async virtual Task<IActionResult> Insert([FromBody] D dto)
        {
            await _baseService.Insert(dto);
            return Ok();
        }

        [HttpPut]
        public async virtual Task<IActionResult> Update([FromBody] D dto)
        {
            await _baseService.Update(dto);
            return Ok();
        }

        [HttpDelete]
        public async virtual Task<IActionResult> Delete(int id)
        {
            await _baseService.Delete(id);
            return Ok();
        }
    }
}