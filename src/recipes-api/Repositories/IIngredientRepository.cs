using recipes_api.Models;

namespace recipes_api.Repositories
{
    public interface IIngredientRepository
    {
        void AddIngredients(string item, int recipeId);
    }
}