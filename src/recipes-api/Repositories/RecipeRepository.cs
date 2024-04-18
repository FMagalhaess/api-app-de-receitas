using recipes_api.Repositories;

public class RecipeRepository
{
    private readonly IRecipesContext _context;

    public RecipeRepository(IRecipesContext context)
    {
        _context = context;
    }
}