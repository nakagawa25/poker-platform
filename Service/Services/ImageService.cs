using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Base;
using Service.Interfaces;

namespace Service.Services
{
    public class ImageService : BaseService<Image, ImageDTO>, IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(
            IImageRepository imageRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper) 
            : base(imageRepository, unitOfWork, mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImageDTO>> GetHomeImages()
        {
            var images = await _imageRepository
                .GetAllQuery()
                .Where(i => i.StageId == null)
                .ToListAsync();

            var imagesDTO = _mapper.Map<IEnumerable<ImageDTO>>(images);

            return imagesDTO;
        }
    }
}
