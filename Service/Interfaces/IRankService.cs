using Domain.DTOs;
using Domain.Entities;
using Service.Base;

namespace Service.Interfaces
{
    public interface IRankService : IBaseService<Rank, RankDTO>
    {
        public Task<IEnumerable<RankDTO>> GetGeneralRanking(int categoryId);
    }
}
