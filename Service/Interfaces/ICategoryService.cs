using Domain.DTOs;
using Domain.Entities;
using Service.Base;

namespace Service.Interfaces
{
    public interface ICategoryService : IBaseService<Category, CategoryDTO>
    {
    }
}
