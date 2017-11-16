namespace DTRDALTests
{
    public interface IRepositoryTest
    {
        /// <summary>
        /// Repository should create one entity
        /// </summary>
        /// <remarks>Test entity for null</remarks>
        void CreateOne();

        /// <summary>
        /// Repository should get one entity by id
        /// </summary>
        /// <remarks>Test entity for null</remarks>
        void GetOneByExistingId();

        /// <summary>
        /// Repository should not get one entity by non-existing id
        /// </summary>
        /// <remarks>Test entity for null</remarks>
        void NotGetOneByNonExistingId();

        /// <summary>
        /// Repository should create all entities
        /// </summary>
        /// <remarks>Test for empty collection</remarks>
        void GetAll();

        /// <summary>
        /// Repository should delete one entity by existing id
        /// </summary>
        /// <remarks>Test return boolean is true</remarks>
        void DeleteByExistingId();

        /// <summary>
        /// Repository should NOT delete one entity by non-existing id
        /// </summary>
        /// <remarks>Test return boolean is false</remarks>
        void NotDeleteByNonExistingId();
    }
}