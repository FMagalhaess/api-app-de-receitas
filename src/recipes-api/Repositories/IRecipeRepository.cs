using recipes_api.Dto;
using recipes_api.Models;

namespace recipes_api.Repositories
{
    public interface IRecipeRepository
    {
        public Recipe AddRecipe(InputRecipeDto recipe);
        public List<InputRecipeDto> GetRecipes();
        void DeleteRecipe(string name);
        public Recipe UpdateRecipe(InputRecipeDto item, string name);
        bool RecipeExists(string name);
        InputRecipeDto GetRecipe(string name);



    }
}