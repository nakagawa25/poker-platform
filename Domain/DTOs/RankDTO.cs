using Domain.Base;

namespace Domain.DTOs
{
    public class RankDTO : BaseDTO
    {
        public int? Position { get; set; }
        public int Score { get; set; }
        public int PlayerId { get; set; }
        public PlayerDTO? Player { get; set; }
        public int StageId { get; set; }
        public StageDTO? Stage { get; set; }
    }
}
