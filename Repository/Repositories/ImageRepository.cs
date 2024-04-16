using Domain.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(PokerPageContext context) : base(context)
        {
        }
    }
}
