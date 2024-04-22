using recipes_api.Repositories;
using recipes_api.Services;
namespace recipes_api.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IRecipesContext _context;

    public UserRepository(IRecipesContext context)
    {
        _context = context;
    }
    public void AddUser(User user)
    {
        try
        {
            user.Role ??= "User";
            ExceptionTryCatch(user);
            _context.Users.Add(user);                
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public User GetUser(string email)
    {
        User toReturn = _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        if (toReturn != null) return toReturn;
        else  throw new Exception("Nao Encontrado");
    }

    public void UpdateUser(User item)
    {
        var toUpdate = _context.Users.Where(x => x.Email.ToLower() == item.Email.ToLower()).FirstOrDefault();

        toUpdate.Name = item.Name;
        toUpdate.Password = item.Password;
        _context.SaveChanges();
    }
    public void DeleteUser(string email)
    {        
        var toRemove = _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        if (toRemove != null) _context.Users.Remove(toRemove);
        else throw new Exception("Nao achado");
    }
    public Exception ExceptionTryCatch(User item)
    {
        if (item.Email == null || item.Name == null || item.Password == null) throw new Exception("Campos obrigatorios nao preenchidos");
        if (UserExists(item.Email)) throw new Exception("Usuario ja existe");
        return null;
    }

    public bool UserExists(string email)
    {
        return _context.Users.Any(x => x.Email.ToLower() == email.ToLower());
    }

}