namespace DTRBLL.BusinessObjects
{
    public class UserDBBO
    {
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
    }
}