using Domain.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace Service.Helpers
{
    public static class ValidationHelpers
    {
        public static bool ValidateUser(UserDTO userDTO)
        {
            if (userDTO == null)
                return false;
            if (userDTO.UserName.Trim().IsNullOrEmpty())
                return false;
            if (userDTO.Password.Trim().IsNullOrEmpty())
                return false;

            return true;
        }
    }
}
