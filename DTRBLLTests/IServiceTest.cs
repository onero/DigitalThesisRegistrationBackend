namespace DTRBLLTests
{
    public interface IServiceTest
    {
        /// <summary>
        /// Service should create one entity
        /// </summary>
        /// <remarks>Test entity for null</remarks>
        void CreateOne();

        /// <summary>
        /// Service should get one entity by id
        /// </summary>
        /// <remarks>Test entity for null</remarks>
        void GetOneByExistingId();

        /// <summary>
        /// Service should not get one entity by non-existing id
        /// </summary>
        /// <remarks>Test entity for null</remarks>
        void NotGetOneByNonExistingId();

        /// <summary>
        /// Service should create all entities
        /// </summary>
        /// <remarks>Test for empty collection</remarks>
        void GetAll();
        
        /// <summary>
        /// Service should delete one entity by existing id
        /// </summary>
        /// <remarks>Test return boolean is true</remarks>
        void DeleteByExistingId();

        /// <summary>
        /// Service should NOT delete one entity by non-existing id
        /// </summary>
        /// <remarks>Test return boolean is false</remarks>
        void NotDeleteByNonExistingId();

        /// <summary>
        /// Service should update one entity by existing id
        /// </summary>
        /// <remarks>Test entity is updated</remarks>
        void UpdateByExistingId();

        /// <summary>
        /// Service should not update one entity by non-existing id
        /// </summary>
        /// <remarks>Test entity is null</remarks>
        void NotUpdateByNonExistingId();
    }
}