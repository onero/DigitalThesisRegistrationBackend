namespace DTRBLL.Converters
{
    public interface IConverter<TEntity, TBusinessObject>
    {
        /// <summary>
        /// Convert a BusinessObject to a Entity
        /// </summary>
        /// <param name="bo"></param>
        /// <returns>Converted Entity</returns>
        TEntity Convert(TBusinessObject bo);

        /// <summary>
        /// Convert a Entity to a BusinessObject
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Converted BusinessObject</returns>
        TBusinessObject Convert(TEntity entity);
    }
}