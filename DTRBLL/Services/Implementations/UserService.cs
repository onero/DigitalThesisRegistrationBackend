using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    internal class UserService : IUserService
    {
        private readonly UserConverter _converter;
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new UserConverter();
        }

        public bool Create(UserBO userBO, UserDBBO userDBBO)
        {
            using (var unitOfWork = _uow)
            {
                var user = _converter.Convert(userBO, userDBBO);
                var result = unitOfWork.UserRepository.Create(user);
                unitOfWork.Complete();
                return result;
            }
        }
    }
}