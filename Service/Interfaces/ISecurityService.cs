using Domain.DTOs;

namespace Service.Interfaces
{
    public interface ISecurityService
    {
        string GenerateToken(UserDTO userDTO);
        string GeneratePasswordHash(UserDTO userDTO);
        bool CompareHashPassword(UserDTO userDTO, string hashedPassword);
    }
}
