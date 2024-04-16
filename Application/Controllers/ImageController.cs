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
    public class ImageController : BaseController<Image, ImageDTO>
    {
        private readonly IImageService _service;
        public ImageController(IImageService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("home")]
        public async Task<IActionResult> GetHomeImages()
        {
            var result = await _service.GetHomeImages();
            return Ok(result);
        }
    }
}