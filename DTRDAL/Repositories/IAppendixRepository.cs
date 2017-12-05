using DTRDAL.Entities;

namespace DTRDAL.Repositories
{
    public interface IAppendixRepository
    {
        /// <summary>
        /// Load Appendix from file
        /// </summary>
        /// <returns>Appendix</returns>
        Appendix Load();

        /// <summary>
        /// Save Appendix to file
        /// </summary>
        /// <param name="appendix">Appendix to save</param>
        /// <returns>True, if saved correctly</returns>
        bool Save(Appendix appendix);
    }
}