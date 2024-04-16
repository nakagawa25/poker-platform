using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Repository.Context;
using Repository.Interfaces;
using Repository.UnitOfWork;
using Service.Base;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services
{
    public class StageService : BaseService<Stage, StageDTO>, IStageService
    {
        private readonly PokerPageContext _dataBaseContext;
        private readonly IStageRepository _stageRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IRankRepository _rankRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StageService(
            PokerPageContext dbContext,
            IStageRepository stageRepository,
            IImageRepository imageRepository,
            IRankRepository rankRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
            : base(stageRepository, unitOfWork, mapper)
        {
            _dataBaseContext = dbContext;
            _stageRepository = stageRepository;
            _imageRepository = imageRepository;
            _rankRepository = rankRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async override Task<StageDTO> GetById(int id)
        {
            var stage = await _stageRepository.GetById(id);

            var stageDto = _mapper.Map<StageDTO>(stage);

            if (stageDto != null && stageDto.Ranking != null)
                stageDto.Ranking = RankingHelpers.SetRankingPosition(stageDto.Ranking).ToList();

            return stageDto;
        }

        public async Task Create(StageInsertDTO stageInput)
        {
            using var transaction = _dataBaseContext.Database.BeginTransaction();
            try
            {
                var stage = new Stage()
                {
                    Name = stageInput.Name,
                    CategoryId = stageInput.CategoryId
                };

                await _stageRepository.Insert(stage);
                await _unitOfWork.SaveChangesAsync();

                var lastStage = _stageRepository
                    .GetAllQuery()
                    .OrderByDescending(x => x.Id)
                    .First();

                stageInput.Id = lastStage.Id;

                await AddNewImages(stageInput);
                await AddNewRanking(stageInput);

                await _unitOfWork.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception error)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro ao criar o Stage. Erro: " + error.Message);
            }
        }

        public async Task Update(StageInsertDTO stageInput)
        {
            using var transaction = _dataBaseContext.Database.BeginTransaction();
            try
            {
                var oldStage = await _stageRepository.GetById(stageInput.Id);

                await DeleteOldImages(stageInput, oldStage);
                await DeleteOldRanking(stageInput, oldStage);
                await AddNewImages(stageInput);
                await AddNewRanking(stageInput);

                await _unitOfWork.SaveChangesAsync();

                oldStage.Name = stageInput.Name;
                oldStage.CategoryId = stageInput.CategoryId;
                await _stageRepository.Update(oldStage);

                await _unitOfWork.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception error)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Erro ao atualizar o Stage. Erro: " + error.Message);
            }
        }

        #region Utils Methods
        private async Task AddNewImages(StageInsertDTO stageInput)
        {
            var newImages = stageInput.Images.Where(x => x.Id == 0);

            foreach (var image in newImages)
            {
                image.StageId = stageInput.Id;
                var imageEntity = _mapper.Map<Image>(image);
                await _imageRepository.Insert(imageEntity);
            }
        }

        private async Task AddNewRanking(StageInsertDTO stageInput)
        {
            var newRanking = stageInput.Ranking.Where(x => x.Id == 0);

            foreach (var rank in newRanking)
            {
                rank.StageId = stageInput.Id;
                var rankEntity = _mapper.Map<Rank>(rank);
                await _rankRepository.Insert(rankEntity);
            }
        }

        private async Task DeleteOldImages(StageInsertDTO stageInput, Stage oldStage)
        {
            var imagesToDelete = oldStage?.Images?
                .Where(oldImage => !stageInput.Images.Any(newImage => newImage.Id == oldImage.Id))
                .ToList();

            if (imagesToDelete != null)
            {
                foreach (var image in imagesToDelete)
                    await _imageRepository.Delete(image.Id);
            }
        }

        private async Task DeleteOldRanking(StageInsertDTO stageInput, Stage oldStage)
        {
            var rankingToDelete = oldStage?.Ranking?
                .Where(oldRank => !stageInput.Ranking.Any(newRank => newRank.Id == oldRank.Id))
                .ToList();

            if (rankingToDelete != null)
            {
                foreach (var rank in rankingToDelete)
                    await _rankRepository.Delete(rank.Id);
            } 
        }
        #endregion
    }
}
