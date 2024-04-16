using Domain.Base;

namespace Domain.DTOs
{
    public class StageInsertDTO : BaseDTO
    {
        public StageInsertDTO()
        {
            Name = string.Empty;
            Images = new List<ImageDTO>();
            Ranking = new List<RankDTO>();
        }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
        public IEnumerable<RankDTO> Ranking { get; set; }
    }
}