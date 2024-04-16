using Domain.DTOs;
using Domain.Entities;
using Service.Base;

namespace Service.Interfaces
{
    public interface IImageService : IBaseService<Image, ImageDTO>
    {
        Task<IEnumerable<ImageDTO>> GetHomeImages();
    }
}
