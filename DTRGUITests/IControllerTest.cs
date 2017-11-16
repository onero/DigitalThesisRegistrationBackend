namespace DTRGUITests
{
    public interface IControllerTest
    {
        /// <summary>
        /// Controller should Get all entities
        /// </summary>
        /// <remarks>Test against empty collection</remarks>
        void GetAll();

        /// <summary>
        /// Controller should Get entity by id
        /// </summary>
        /// <remarks>Test against entity for null</remarks>
        void GetByExistingId();

        /// <summary>
        /// Controller should NOT Get entity by non-existing id
        /// </summary>
        /// <remarks>Test against type "NotFoundObjectResult"</remarks>
        void NotGetByNonExistingId_ReturnNotFound();

        /// <summary>
        /// Controller should Post valid entity
        /// </summary>
        /// <remarks>Test against type "CreatedResult"</remarks>
        void PostWithValidObject();

        /// <summary>
        /// Controller should NOT Post invalid entity
        /// </summary>
        /// <remarks>Test against type "BadRequestObjectResult"</remarks>
        void NotPostWithInvalidObject_ReturnBadRequest();

        /// <summary>
        /// Controller should NOT Post null entity
        /// </summary>
        /// <remarks>Test against type "BadRequestObjectResult"</remarks>
        void NotPostWithNull_ReturnBadRequest();

        /// <summary>
        /// Controller should Delete entity by id
        /// </summary>
        /// <remarks>Test against type "OkObjectResult"</remarks>
        void DeleteByExistingId_ReturnOk();

        /// <summary>
        /// Controller should NOT Delete entity by non-existing id
        /// </summary>
        /// <remarks>Test against type "NotFoundObjectResult"</remarks>
        void NotDeleteByNonExistingId_ReturnNotFound();

        /// <summary>
        /// Controller should Update entity
        /// </summary>
        /// <remarks>Test against type "OkObjectResult"</remarks>
        void UpdateWithValidObject_ReturnOk();

        /// <summary>
        /// Controller should NOT Update null entity
        /// </summary>
        /// <remarks>Test against type "BadRequestObjectResult"</remarks>
        void NotUpdateWithNull_ReturnBadRequest();

        /// <summary>
        /// Controller should NOT Update entity with mismatching id
        /// </summary>
        /// <remarks>Test against type "BadRequestObjectResult"</remarks>
        void NotUpdateWithMisMatchingIds_ReturnBadRequest();

        /// <summary>
        /// Controller should NOT Update invalid entity
        /// </summary>
        /// <remarks>Test against type "BadRequestObjectResult"</remarks>
        void NotUpdateWithInvalidObject_ReturnBadRequest();

        /// <summary>
        /// Controller should NOT Update entity with non-existing id
        /// </summary>
        /// <remarks>Test against type "NotFoundObjectResult"</remarks>
        void NotUpdateWithNonExistingId_ReturnNotFound();
    }
}