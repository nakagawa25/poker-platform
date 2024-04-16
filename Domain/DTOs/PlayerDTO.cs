using Domain.Base;

namespace Domain.DTOs
{
    public class PlayerDTO : BaseDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
