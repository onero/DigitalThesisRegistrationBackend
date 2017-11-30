namespace DTRBLLTests
{
    public interface IConverterTest
    {
        // TODO ALH: Document
        void ConvertEntity();
        void ConvertBO();
        void NotConvertEntity_WithNull();
        void NotConvertBO_WithNull();
    }
}