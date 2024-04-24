namespace recipes_api.Services;
public interface IHashPasswords
{
    public string GenerateHash(string password);
    bool VerifyPassword(string password, string hash);
}