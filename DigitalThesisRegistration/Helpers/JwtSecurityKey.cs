using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DigitalThesisRegistration.Helpers
{
    public static class JwtSecurityKey
    {
        private static byte[] _secretBytes = Encoding.UTF8.GetBytes("A secret for HmacSha256");

        public static SymmetricSecurityKey Key => new SymmetricSecurityKey(_secretBytes);

        public static void SetSecret(string secret)
        {
            _secretBytes = Encoding.UTF8.GetBytes(secret);
        }

    }
}