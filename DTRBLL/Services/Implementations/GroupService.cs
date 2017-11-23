using System.Collections.Generic;
using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    internal class GroupService : IGroupService
    {
        private readonly IUnitOfWork _uow;
        private readonly GroupConverter _converter;

        public GroupService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new GroupConverter();
        }

        public GroupBO Create(GroupBO bo)
        {
            using (var unitOfWork = _uow)
            {
                var convertedBO = _converter.Convert(bo);
                var createdEntity = unitOfWork.GroupRepository.Create(convertedBO);
                unitOfWork.Complete();
                return _converter.Convert(createdEntity);
            }
        }

        public GroupBO Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<GroupBO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public GroupBO Update(GroupBO bo)
        {
            throw new System.NotImplementedException();
        }
    }
}