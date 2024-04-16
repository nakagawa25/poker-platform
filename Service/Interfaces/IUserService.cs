using Domain.DTOs;
using Domain.Entities;
using Service.Base;

namespace Service.Interfaces
{
    public interface IUserService : IBaseService<User, UserDTO>
    {
        public bool ValidateUserLogin(UserDTO userDTO);
    }
}
