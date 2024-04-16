using AutoMapper;
using Repository.Base;using Repository.UnitOfWork;

namespace Service.Base{    public class BaseService<T, D> : IBaseService<T, D> where T : class where D : class    {
        private readonly IBaseRepository<T> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseService(            IBaseRepository<T> baseRepository,             IUnitOfWork unitOfWork,             IMapper mapper)        {
            _baseRepository = baseRepository;            _unitOfWork = unitOfWork;            _mapper = mapper;        }        public virtual async Task<IEnumerable<D>> GetAll()        {            var entities = await _baseRepository.GetAll();            var dto = _mapper.Map<IEnumerable<D>>(entities);            return dto;        }        public virtual async Task<D> GetById(int id)        {            var entity = await _baseRepository.GetById(id);            var dto = _mapper.Map<D>(entity);            return dto;        }

        public virtual async Task Insert(D dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _baseRepository.Insert(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task Update(D dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }}