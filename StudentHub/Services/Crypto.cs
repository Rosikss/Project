namespace StudentHub.Services
{
    public static class Crypto
    {
        public static string GetHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool CompareHash(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
