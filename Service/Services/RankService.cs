using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Base;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services
{
    public class RankService : BaseService<Rank, RankDTO>, IRankService
    {
        private readonly IRankRepository _rankRepository;
        private readonly IMapper _mapper;

        public RankService(
            IRankRepository rankRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper) 
            : base(rankRepository, unitOfWork, mapper)
        {
            _rankRepository = rankRepository;
            _mapper = mapper;
        }

        #region Get General Ranking
        public async Task<IEnumerable<RankDTO>> GetGeneralRanking(int categoryId)
        {
            var allRankings = await _rankRepository
                .GetAllQuery()
                .Where(r => r.Stage.CategoryId == categoryId)
                .ToListAsync();

            var activePlayers = allRankings
                .Select(r => r.Player)
                .Distinct()
                .Where(p => p.IsActive);

            var generalRanking = new List<Rank>();

            foreach (var player in activePlayers)
            {
                var playerRanking = allRankings.Where(r => r.PlayerId == player.Id);
                var playerRankCalculated = CalculateRankByPlayer(playerRanking, player);
                generalRanking.Add(playerRankCalculated);
            }

            var generalRankingDTO = _mapper.Map<IEnumerable<RankDTO>>(generalRanking);

            generalRankingDTO = RankingHelpers.SetRankingPosition(generalRankingDTO).ToList();

            return generalRankingDTO;
        }

        private static Rank CalculateRankByPlayer(IEnumerable<Rank> playerRanking, Player player)
        {
            var rank = new Rank()
            {
                Score = playerRanking.Sum(r => r.Score),
                Player = player,
                PlayerId = player.Id,
            };

            return rank;
        }
        #endregion
    }
}