using System.Security.Cryptography;

namespace WeatherAPI.PasswordHasher;


public interface IPasswordHasher
{
    bool Verify(string passwordHash, string inputPassword);
    string Hash(string password);
}

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
    private const char DeLimiter = ';';

    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(count: SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithmName, KeySize);
        
        //string.join() concatenates the elements of a specified array or the members of a collection, using the specified seperator. 
        return string.Join(DeLimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Verify(string passwordHash, string inputPassword)
    {
        var elements = passwordHash.Split(DeLimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlgorithmName, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }

}