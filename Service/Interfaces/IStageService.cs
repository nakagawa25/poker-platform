using Domain.DTOs;
using Domain.Entities;
using Service.Base;

namespace Service.Interfaces
{
    public interface IStageService : IBaseService<Stage, StageDTO>
    {
        Task Create(StageInsertDTO stageInput);
        Task Update(StageInsertDTO stageInput);
    }
}
