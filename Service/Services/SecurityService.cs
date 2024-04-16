using Domain.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Helpers;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;

        public SecurityService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Password Hash
        public string GeneratePasswordHash(UserDTO userDTO)
        {
            if (!ValidationHelpers.ValidateUser(userDTO))
                return string.Empty;

            var hash = SecurityHelpers.GeneratePasswordHash(userDTO.Password);

           return hash;

        }

        public bool CompareHashPassword(UserDTO userDTO, string hashedPassword)
        {
            if (!ValidationHelpers.ValidateUser(userDTO) || hashedPassword.IsNullOrEmpty())
                return false;

            if (userDTO.Password.Equals(hashedPassword))
                return true;

            return false;
        }
        #endregion

        #region JWT - Bearer Token
        public string GenerateToken(UserDTO userDTO)
        {
            if (!ValidationHelpers.ValidateUser(userDTO))
                return string.Empty;

            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["SecurityKey"]);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(userDTO),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            var token = handler.CreateToken(tokenDescriptor);
            var stringToken = handler.WriteToken(token);

            return stringToken;
        }

        private static ClaimsIdentity GenerateClaims(UserDTO userDTO)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, userDTO.UserName));

            return ci;
        }
        #endregion
    }
}
