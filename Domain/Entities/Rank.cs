using Domain.Base;

namespace Domain.Entities
{
    public class Rank : BaseEntity
    {
        public int Score { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }
    }
}
