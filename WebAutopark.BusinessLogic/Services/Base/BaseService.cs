using AutoMapper;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.BusinessLogic.Base.Services
{
    public abstract class BaseService<TDto, TEntity> : IDataService<TDto>
        where TDto : class
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            _repository.Create(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<TDto> GetAllItems()
        {
            var entities = _repository.GetAllItems();
            var dtoItems = _mapper.Map<IEnumerable<TDto>>(entities);
            return dtoItems;
        }

        public TDto GetItem(int id)
        {
            var entity = _repository.GetItem(id);
            var dtoItem = _mapper.Map<TDto>(entity);
            return dtoItem;
        }

        public void Update(TDto item)
        {
            var entity = _mapper.Map<TEntity>(item);
            _repository.Update(entity);
        }
    }
}
