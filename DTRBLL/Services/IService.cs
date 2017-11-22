using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DigitalThesisRegistration")]
[assembly: InternalsVisibleTo("DTRBLLTests")]
[assembly: InternalsVisibleTo("DTRControllerTests")]
namespace DTRBLL.Services
{
    public interface IService<TBusinessObject>
    {
        /// <summary>
        /// Create BusinessObject
        /// </summary>
        /// <param name="bo">BusinessObject to create</param>
        /// <returns>Created BusinessObject</returns>
        TBusinessObject Create(TBusinessObject bo);

        /// <summary>
        /// Get BusinessObject by id
        /// </summary>
        /// <param name="id">Id of BusinessObject to get</param>
        /// <returns>BusinessObject</returns>
        TBusinessObject Get(int id);

        /// <summary>
        /// Get all BusinessObjects
        /// </summary>
        /// <returns>Enumerable containing BusinessObjects</returns>
        IList<TBusinessObject> GetAll();

        /// <summary>
        /// Delete BusinessObjects by id
        /// </summary>
        /// <param name="id">Id of BusinessObjects to delete</param>
        /// <returns>Boolean value of operation: true if succeeded, false if failed</returns>
        bool Delete(int id);

        /// <summary>
        /// Update BusinessObject
        /// </summary>
        /// <param name="bo">BusinessObject to update</param>
        TBusinessObject Update(TBusinessObject bo);
    }
}