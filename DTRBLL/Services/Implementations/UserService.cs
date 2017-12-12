using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly UserConverter _converter;
        private readonly GroupConverter _groupConverter;
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new UserConverter();
            _groupConverter = new GroupConverter();
        }

        public User Create(UserBO userBO, UserDBBO userDBBO)
        {
            using (var unitOfWork = _uow)
            {
                var user = _converter.Convert(userBO, userDBBO);
                var result = unitOfWork.UserRepository.Create(user);
                unitOfWork.Complete();
                if (result.Role.Equals("Group"))
                {
                    var newGroup = new GroupBO
                    {
                        ContactEmail = result.Username,
                        UserId = result.Id
                    };
                    var convertedGroup = _groupConverter.Convert(newGroup);
                    unitOfWork.GroupRepository.Create(convertedGroup);
                }
                unitOfWork.Complete();
                return result;
            }
        }
    }
}