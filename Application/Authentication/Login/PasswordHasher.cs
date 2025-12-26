namespace Application.Authentication.Login
{
    public class PasswordHasher
    {
        public static string Hash(string password)
        {
            // Implement a secure hashing algorithm here
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
        public static bool Verify(string password, string hashedPassword)
        {
            // Implement verification logic here
            var hashedInput = Hash(password);
            return hashedInput == hashedPassword;
        }
    }
}
