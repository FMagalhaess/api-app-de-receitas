using BCrypt.Net;
using System.Threading.Tasks;

namespace recipes_api.Services;
public class HashPasswords : IHashPasswords
{
    public string GenerateHash(string password) {
        int Salts = 10;
        var Hashed = BCrypt.Net.BCrypt.HashPassword(password, Salts);
        return Hashed;
    }

    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}