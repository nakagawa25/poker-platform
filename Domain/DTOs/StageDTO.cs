using Domain.Base;

namespace Domain.DTOs
{
    public class StageDTO : BaseDTO
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<ImageDTO>? Images { get; set; }
        public ICollection<RankDTO>? Ranking { get; set; }
    }
}
