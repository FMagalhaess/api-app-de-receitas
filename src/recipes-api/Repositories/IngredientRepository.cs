using recipes_api.Repositories;
namespace recipes_api.Repositories;
public class IngredientRepository : IIngredientRepository
{
    private readonly IRecipesContext _context;

    public IngredientRepository(IRecipesContext context)
    {
        _context = context;
    }
    public void AddIngredients(string item, int recipeId)
    {
        Ingredient ToReturn = new() { Name = item, RecipeId = recipeId };
        _context.Ingredients.Add(ToReturn);
        _context.SaveChanges();
    }
}