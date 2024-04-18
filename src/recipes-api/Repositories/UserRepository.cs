using recipes_api.Repositories;
namespace recipes_api.Repositories;
public class UserRepository
{
    private readonly IRecipesContext _context;

    public UserRepository(IRecipesContext context)
    {
        _context = context;
    }
}