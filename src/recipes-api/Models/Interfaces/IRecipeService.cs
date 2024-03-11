using recipes_api.Models;
using System.Collections.Generic;

namespace recipes_api.Services;

public interface IRecipeService
{
    List<Recipe> GetRecipes();
    Recipe GetRecipe(string name);
    Recipe AddRecipe(Recipe item);
    Recipe UpdateRecipe(Recipe item);
    void DeleteRecipe(string name);
    bool RecipeExists(string name);
}
