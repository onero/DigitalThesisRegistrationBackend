using DTRBLL.BusinessObjects;
using DTRDAL.Entities;

namespace DTRBLL.Converters.Implementations
{
    internal class AppendixConverter : IConverter<Appendix, AppendixBO>
    {
        public Appendix Convert(AppendixBO bo)
        {
            if (bo == null) return null;
            return new Appendix
            {
                Condition = bo.Condition,
                Resources = bo.Resources
            };
        }

        public AppendixBO Convert(Appendix entity)
        {
            if (entity == null) return null;
            return new AppendixBO
            {
                Condition = entity.Condition,
                Resources = entity.Resources
            };
        }
    }
}