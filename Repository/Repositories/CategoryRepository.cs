using Domain.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PokerPageContext context) : base(context)
        {
        }
    }
}
