using DTRBLL.BusinessObjects;

namespace DTRBLL.Services
{
    public interface IAppendixService
    {
        /// <summary>
        /// Load Appendix from file
        /// </summary>
        /// <returns>Appendix</returns>
        AppendixBO Load();

        /// <summary>
        /// Save Appendix to file
        /// </summary>
        /// <param name="appendix">Appendix to save</param>
        /// <returns>True, if saved correctly</returns>
        bool Save(AppendixBO appendix);
    }
}