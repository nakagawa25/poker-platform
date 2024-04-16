using Domain.Base;

namespace Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
