using DTRBLL.BusinessObjects;
using DTRBLL.Converters.Implementations;
using DTRDAL.UOW;

namespace DTRBLL.Services.Implementations
{
    internal class AppendixService : IAppendixService
    {
        private readonly IUnitOfWork _uow;
        private readonly AppendixConverter _converter;

        public AppendixService(IUnitOfWork uow)
        {
            _uow = uow;
            _converter = new AppendixConverter();
        }

        public AppendixBO Load()
        {
            using (var unitOfWork = _uow)
            {
                var appendixFromDB = unitOfWork.AppendixRepository.Load();
                if (appendixFromDB == null) return null;
                unitOfWork.Complete();
                return _converter.Convert(appendixFromDB);
            }
        }

        public bool Save(AppendixBO appendix)
        {
            using (var unitOfWork = _uow)
            {
                var convertedAppendix = _converter.Convert(appendix);
                var savedAppendix = unitOfWork.AppendixRepository.Save(convertedAppendix);
                unitOfWork.Complete();
                return savedAppendix;
            }
        }
    }
}