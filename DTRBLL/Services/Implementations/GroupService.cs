using System.Collections.Generic;
using System.Linq;
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
            using (var unitOfWork = _uow)
            {
                var entityFromDB = unitOfWork.GroupRepository.Get(id);
                return _converter.Convert(entityFromDB);
            }
        }

        public IList<GroupBO> GetAll()
        {
            using (var unitOfWork = _uow)
            {
                return unitOfWork.GroupRepository.GetAll().Select(_converter.Convert).ToList();
            }
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