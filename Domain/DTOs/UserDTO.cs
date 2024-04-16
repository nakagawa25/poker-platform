using Domain.Base;

namespace Domain.DTOs
{
    public class UserDTO : BaseDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
