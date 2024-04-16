using Domain.Base;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public virtual ICollection<Stage>? Stages { get; set; }
    }
}
