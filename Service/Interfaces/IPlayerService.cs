using Domain.DTOs;
using Domain.Entities;
using Service.Base;

namespace Service.Interfaces
{
    public interface IPlayerService : IBaseService<Player, PlayerDTO>
    {
    }
}
