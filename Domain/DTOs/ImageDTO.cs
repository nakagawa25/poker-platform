using Domain.Base;

namespace Domain.DTOs
{
    public class ImageDTO : BaseDTO
    {
        public string Url { get; set; }
        public int? StageId { get; set; }
        public StageDTO? Stage { get; set; }
    }
}
