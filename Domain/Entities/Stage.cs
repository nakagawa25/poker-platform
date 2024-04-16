using Domain.Base;

namespace Domain.Entities
{
    public class Stage : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Image>? Images { get; set; }
        public virtual ICollection<Rank>? Ranking { get; set; }
    }
}
