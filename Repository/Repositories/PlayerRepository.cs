using Domain.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(PokerPageContext context) : base(context)
        {
        }
    }
}
