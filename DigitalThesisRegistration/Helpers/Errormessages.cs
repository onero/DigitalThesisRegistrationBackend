namespace DigitalThesisRegistration.Helpers
{
    public static class ErrorMessages
    {
        public static string InvalidEntityString => "Entity cannot be null";
        public static string MismatchingIdString => "Provided id doesn't match entity id";
        public static string NotFoundString => "Id of entity doesn't exist";
    }
}