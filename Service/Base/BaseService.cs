﻿using AutoMapper;
using Repository.Base;

namespace Service.Base
        private readonly IBaseRepository<T> _baseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BaseService(
            _baseRepository = baseRepository;

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
    }