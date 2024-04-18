using recipes_api.Repositories;
namespace recipes_api.Repositories;
public class IngredientsRepository
{
    private readonly IRecipesContext _context;

    public IngredientsRepository(IRecipesContext context)
    {
        _context = context;
    }
}