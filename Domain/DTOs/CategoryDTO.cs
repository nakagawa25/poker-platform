using Domain.Base;

namespace Domain.DTOs
{
    public class CategoryDTO : BaseDTO
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public ICollection<StageDTO>? Stages { get; set; }
    }
}
