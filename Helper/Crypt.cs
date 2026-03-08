namespace ContactRegistration.Helper;

public static class Crypt
{
    public static string Encrypt(this string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);;
        return passwordHash;
    }

    public static bool Decrypt(this string password,  string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}