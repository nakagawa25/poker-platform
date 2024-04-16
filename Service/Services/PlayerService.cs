using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Base;
using Service.Interfaces;

namespace Service.Services
{
    public class PlayerService : BaseService<Player, PlayerDTO>, IPlayerService
    {
        public PlayerService(
            IPlayerRepository playerRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper) 
            : base(playerRepository, unitOfWork, mapper)
        {
        }
    }
}
