using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.Entities;
using DTRDAL.Repositories.Implementations;
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
                if (result.Role.Equals(Roles.Group))
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

        public (UserBO userBo, UserDBBO userDbbo) Get(string username)
        {
            var userFromDB = _uow.UserRepository.Get(username);
            if (userFromDB == null) return (null, null);
            if (!userFromDB.Role.Equals(Roles.Group))
            {
                _uow.Dispose();
            }
            return _converter.Convert(userFromDB);
        }
    }
}