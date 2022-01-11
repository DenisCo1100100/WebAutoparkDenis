using AutoMapper;
using WebAutopark.BusinessLogic.Base.Services;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.BusinessLogic.Services
{
    public class ComponentService : BaseService<ComponentDto, Component>
    {
        public ComponentService(IRepository<Component> repository, IMapper mapper) 
            : base(repository, mapper)
        {}
    }
}