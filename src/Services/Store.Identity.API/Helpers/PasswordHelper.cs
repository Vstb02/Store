namespace Store.Identity.API.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string str)
        {
            return BCrypt.Net.BCrypt.HashPassword(str); ;
        }

        public static bool ComparePasswordWithHash(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
