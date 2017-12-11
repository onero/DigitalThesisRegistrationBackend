namespace DigitalThesisRegistration.Helpers
{
    public static class UserHelper
    {
        /// <summary>
        /// This method computes a hashed and salted password using the HMACSHA512 algorithm.
        /// The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        /// the SHA512 hash function. When instantiated with the parameterless constructor (as
        /// here) a randomly Key is generated. This key is used as a password salt.

        /// The computation is performed as shown below:
        /// passwordHash = SHA512(password + Key)

        /// A password salt randomizes the password hash so that two identical passwords will
        /// have significantly different hash values. This protects against sophisticated attempts
        /// to guess passwords, such as a rainbow table attack.
        /// The password hash is 512 bits (=64 bytes) long.
        /// The password salt is 1024 bits (=128 bytes) long.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// This method verifies that the password entered by a user corresponds to the stored
        /// password hash for this user. The method computes a Hash-based Message Authentication
        /// Code (HMAC) using the SHA512 hash function. The inputs to the computation is the
        /// password entered by the user and the stored password salt for this user. If the
        /// computed hash value is identical to the stored password hash, the password entered
        /// by the user is correct, and the method returns true.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns>Boolean for state of success</returns>
        public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
    }
}