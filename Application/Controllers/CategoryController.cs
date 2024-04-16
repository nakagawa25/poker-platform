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
    public class CategoryController : BaseController<Category, CategoryDTO>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }

        [AllowAnonymous]
        public override Task<IActionResult> GetAll()
        {
            return base.GetAll();
        }

        public override Task<IActionResult> Update([FromBody] CategoryDTO dto)
        {
            dto.Stages = null;
            return base.Update(dto);
        }
    }
}
