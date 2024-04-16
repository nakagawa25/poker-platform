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
    public class CategoryService : BaseService<Category, CategoryDTO>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper) 
            : base(categoryRepository, unitOfWork, mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public override async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categories = await _categoryRepository
                .GetAllQuery()
                .AsNoTracking()
                .Include(c => c.Stages)
                .OrderBy(c => c.Index)
                .ToListAsync();

            var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return categoriesDTO;
        }
    }
}