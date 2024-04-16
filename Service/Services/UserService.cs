using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Base;
using Service.Helpers;
using Service.Interfaces;
namespace Service.Services
{
    public class UserService : BaseService<User, UserDTO>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public UserService(
            ISecurityService securityService,
            IUserRepository userRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper) 
            : base(userRepository, unitOfWork, mapper) 
        { 
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public override Task Insert(UserDTO dto)
        {
            var hash = _securityService.GeneratePasswordHash(dto);

            if (hash == null)
                throw new UserException("Não foi possível gerar o HASH da senha do Usuário: " + dto.UserName);

            dto.Password = hash;

            return base.Insert(dto);
        }

        #region Login Validation
        public bool ValidateUserLogin(UserDTO userDTO)
        {
            if (userDTO.UserName.Trim().IsNullOrEmpty()) 
            {
                throw new LoginException("O Usuário não pode ser vazio. ");
            }

            if (userDTO.Password.Trim().IsNullOrEmpty())
            {
                throw new LoginException("A senha não pode ser vazia. ");
            }

            var user = _userRepository
                .GetAllQuery()
                .Where(u => u.UserName == userDTO.UserName)
                .FirstOrDefault() ?? throw new LoginException("Esse usuário não existe. ");

            var hashedPassword = SecurityHelpers.GeneratePasswordHash(userDTO.Password);

            if (!user.Password.Equals(hashedPassword))
            {
                throw new LoginException("Senha incorreta. ");
            }

            return true;
        }
        #endregion
    }
}
