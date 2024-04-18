using recipes_api.Models;
using System.Collections.Generic;
using System.Linq;

namespace recipes_api.Services;

public class RecipeService : IRecipeService
{
    public readonly List<Recipe> recipes;

    public RecipeService()
    {
        this.recipes = new List<Recipe>
        {
            new Recipe { Name = "Bolo de cenoura",
                        RecipeType = RecipesType.sweet,
                        PreparationTime = 0.4,
                        // Ingredients = new List<string> {"1/2 xícara (chá) de óleo", "3 cenouras médias raladas", "4 ovos", "2 xícaras (chá) de açúcar", "2 e 1/2 xícaras (chá) de farinha de trigo", "1 colher (sopa) de fermento em pó"},
                        Directions = "Em um liquidificador, adicione a cenoura, os ovos e o óleo, depois misture. Acrescente o açúcar e bata novamente por 5 minutos. Em uma tigela ou na batedeira, adicione a farinha de trigo e depois misture novamente. Acrescente o fermento e misture lentamente com uma colher. Asse em um forno preaquecido a 180° C por aproximadamente 40 minutos.",
                        Rating = 10},
            new Recipe { Name = "Coxinha",
                        RecipeType = RecipesType.salty,
                        PreparationTime = 0.4,
                        // Ingredients = new List<string> {"4 xícaras de trigo", "4 xícaras de leite", "1 caldo de galinha", "1/2 colher de margarina"},
                        Directions = "Leve ao fogo o leite, a margarina e o caldo. Deixe ferver. Despeje de uma só vez o trigo e mexa bem. Depois retire da panela e coloque sobre a mesa. Sove um pouco e comece a modelar as coxinhas. Coloque para fritar em óleo quente, espere dourar, retire e sirva.",
                        Rating = 7},
            new Recipe { Name = "Pudim de Leite",
                        RecipeType = RecipesType.sweet,
                        PreparationTime = 1.1,
                        // Ingredients = new List<string> {"1 xícara (chá) de açúcar", "1 lata de leite condensado", "2 latas de leite (medida da lata de leite condensado)", "3 ovos"},
                        Directions = "Bata todos os ingredientes do pudim no liquidificador e despeje na forma reservada. Asse em banho-maria, em forno médio (180º C), por cerca de 1 hora e 30 minutos. Depois de frio, leve para gelar por cerca de 6 horas. Desenforme e sirva a seguir.",
                        Rating = 9}
        };
    }

    public Recipe AddRecipe(Recipe item)
    {
        ExceptionTryCatch(item);
        recipes.Add(item);
        return item;
    }

    public void DeleteRecipe(string name)
    {
        var toRemove = this.recipes.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        recipes.Remove(toRemove);
    }

    public bool RecipeExists(string name)
    {
        if (recipes.Any(x => x.Name.ToLower() == name.ToLower()))
        {
            return true;
        }
        else
        {
            throw new Exception("Nao Encontrado");
        }
    }

    public Recipe GetRecipe(string name)
    {
        Recipe recipeToReturn = recipes.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        if (recipeToReturn != null)
        {
            return recipeToReturn;
        }
        else
        {
            throw new Exception("Nao Encontrado");
        }
    }

    public List<Recipe> GetRecipes()
    {
        return recipes.ToList();
    }

    public Recipe UpdateRecipe(Recipe item, string name)
    {
        var toUpdate = recipes.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        ExceptionTryCatch(item);
        if (toUpdate != null)
        {
            toUpdate.Name = item.Name;
            toUpdate.RecipeType = item.RecipeType;
            if (item.PreparationTime != 0) toUpdate.PreparationTime = item.PreparationTime;
            // toUpdate.Ingredients = item.Ingredients;
            toUpdate.Directions = item.Directions;
            if (item.Rating != 0) toUpdate.Rating = item.Rating;
            return toUpdate;
        }        
        throw new Exception("recipe not found");
        
    }
    public Exception ExceptionTryCatch(Recipe item)
    {
        if (item.Name == null || item.Name == "" || item.Name == " " || item.Name == string.Empty)
        {
            throw new Exception("Name is required");
        }
        if (item.Rating < 0 || item.Rating > 11)
        {
            throw new Exception("Rating must be between 0 and 10");
        }
        if (item.PreparationTime < 0)
        {
            throw new Exception("Preparation time must be greater than 0");
        }
        // if (item.Ingredients == null || item.Ingredients.Count == 0)
        // {
        //     throw new Exception("Ingredients are required");
        // }
        if (item.Directions == null || item.Directions == "" || item.Directions == " " || item.Directions == string.Empty)
        {
            throw new Exception("Directions are required");
        }
        return null;
    }
}

