using Domain.DTOs;

namespace Service.Helpers
{
    public static class RankingHelpers
    {
        public static IEnumerable<RankDTO> SetRankingPosition(IEnumerable<RankDTO> ranking)
        {
            var rankingOrdered = ranking
                .OrderByDescending(r => r.Score)
                .ToList();

            int position = 1;

            foreach (var rank in rankingOrdered)
            {
                rank.Position = position;
                position++;
            }

            return rankingOrdered;
        }
    }
}
