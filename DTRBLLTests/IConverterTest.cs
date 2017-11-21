namespace DTRBLLTests
{
    public interface IConverterTest
    {
        void ConvertEntity();
        void ConvertBO();
        void NotConvertEntity_WithNull();
        void NotConvertBO_WithNull();
    }
}