using recipes_api.Models;

namespace recipes_api.Repositories
{
    public interface IRecipeRepository
    {
        public Recipe AddRecipe(Recipe recipe);
        public List<Recipe> GetRecipes();
        void DeleteRecipe(string name);
        public Recipe UpdateRecipe(Recipe item, string name);
        bool RecipeExists(string name);
        Recipe GetRecipe(string name);



    }
}