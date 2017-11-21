using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DTRDALTests")]

namespace DTRDAL.Repositories
{
    public interface IRespository<TEntity>
    {
        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="ent">Entity to create</param>
        /// <returns>Created entity</returns>
        TEntity Create(TEntity ent);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Id of entity to get</param>
        /// <returns>Entity</returns>
        TEntity Get(int id);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>Enumerable containing entities</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id">Id of entity to delete</param>
        /// <returns>Boolean value of operation: true if succeeded, false if failed</returns>
        bool Delete(int id);
    }
}