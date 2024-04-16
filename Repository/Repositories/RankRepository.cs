using Domain.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class RankRepository : BaseRepository<Rank>, IRankRepository
    {
        public RankRepository(PokerPageContext context) : base(context)
        {
        }
    }
}
