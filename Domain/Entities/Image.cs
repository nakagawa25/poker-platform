using Domain.Base;

namespace Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Url { get; set; }
        public int? StageId { get; set; }
        public virtual Stage? Stage { get; set; }
    }
}
