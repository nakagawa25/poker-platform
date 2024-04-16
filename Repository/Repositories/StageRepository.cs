using Domain.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class StageRepository : BaseRepository<Stage>, IStageRepository
    {
        public StageRepository(PokerPageContext context) : base(context)
        {
        }
    }
}
