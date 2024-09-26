using recipes_api;
using recipes_api.Services;
using recipes_api.Models;
using recipes_api.Repositories;
using Microsoft.EntityFrameworkCore;
using recipes_api.Dto;
namespace recipes_api.Repositories;
public class RecipeRepository : IRecipeRepository
{
    private readonly IRecipesContext _context;
    private readonly IIngredientRepository _ingredientContext;

    public RecipeRepository(IRecipesContext context, IIngredientRepository ingredientContext)
    {
        _context = context;
        _ingredientContext = ingredientContext;
    }

    public Recipe AddRecipe(InputRecipeDto item)
    {
        ExceptionTryCatch(item);
        Recipe toAdd = ConvertInputToOutputRecipe(item);
        _context.Recipes.Add(toAdd);
        _context.SaveChanges();

        if (toAdd != null && toAdd.RecipeId > 0)
        {
            foreach (var ingredient in item.Ingredients)
            {
                _ingredientContext.AddIngredients(ingredient, toAdd.RecipeId);
            }
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Falha ao adicionar a receita.");
        }

        return toAdd;
    }

    public List<InputRecipeDto> GetRecipes()
    {
        var recipes = (from recipe in _context.Recipes
               select new InputRecipeDto
               {
                   RecipeId = recipe.RecipeId,
                   Name = recipe.Name,
                   RecipeType = recipe.RecipeType,
                   PreparationTime = recipe.PreparationTime,
                   Directions = recipe.Directions,
                   Rating = recipe.Rating,
                   Ingredients = (from ingredient in _context.Ingredients
                                  where ingredient.RecipeId == recipe.RecipeId
                                  select ingredient.Name).ToList()
               }).ToList();

                                        return recipes;
    }

    
    public InputRecipeDto GetRecipe(string name)
    {
        InputRecipeDto recipeToReturn = (from recipe in _context.Recipes where recipe.Name == name
               select new InputRecipeDto
               {
                   RecipeId = recipe.RecipeId,
                   Name = recipe.Name,
                   RecipeType = recipe.RecipeType,
                   PreparationTime = recipe.PreparationTime,
                   Directions = recipe.Directions,
                   Rating = recipe.Rating,
                   Ingredients = (from ingredient in _context.Ingredients
                                  where ingredient.RecipeId == recipe.RecipeId
                                  select ingredient.Name).ToList()
               }).FirstOrDefault();
        if (recipeToReturn != null)
        {
            return recipeToReturn;
        }
        else
        {
            throw new Exception("Nao Encontrado");
        }
    }
    public InputRecipeDto GetRecipeById(int recipeId)
    {
        InputRecipeDto recipeToReturn = (from recipe in _context.Recipes where recipe.RecipeId == recipeId
               select new InputRecipeDto
               {
                   RecipeId = recipe.RecipeId,
                   Name = recipe.Name,
                   RecipeType = recipe.RecipeType,
                   PreparationTime = recipe.PreparationTime,
                   Directions = recipe.Directions,
                   Rating = recipe.Rating,
                   Ingredients = (from ingredient in _context.Ingredients
                                  where ingredient.RecipeId == recipe.RecipeId
                                  select ingredient.Name).ToList()
               }).FirstOrDefault();
        if (recipeToReturn != null)
        {
            return recipeToReturn;
        }
        else
        {
            throw new Exception("Nao Encontrado");
        }
    }
    public void UpdateRecipe(InputRecipeDto item, string recipeId)
    {
            RecipeExists(recipeId);
            int.TryParse(recipeId, out int recipeIdInput);
            InputRecipeDto recipeFromContext = GetRecipeById(recipeIdInput);
            Recipe Converted = ConvertInputToOutputRecipe(recipeFromContext);
            Converted.RecipeId = recipeIdInput;
            if (recipeFromContext != null)
            {
                UpdateName(item.Name, Converted);
                UpdatePreparationTime(item.PreparationTime, Converted);
                UpdateDirections(item.Directions, Converted);
                UpdateRating(item.Rating, Converted);
                UpdateIngredients(item.Ingredients, item, recipeIdInput);
                _context.Recipes.Update(Converted);
                _context.SaveChanges();
            }        
    }
    public void DeleteRecipe(string recipeId)
    {
        try
        {
            RecipeExists(recipeId);
            int.TryParse(recipeId, out int recipeIdInput);
            var toRemove = _context.Recipes.Where(x => x.RecipeId == recipeIdInput).FirstOrDefault();
            _context.Recipes.Remove(toRemove);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void DeleteAllIngredients(int recipeId)
    {
        _context.Ingredients.RemoveRange(_context.Ingredients.Where(x => x.RecipeId == recipeId));
        _context.SaveChanges();
    }
    public void UpdateName(string newName, Recipe RecipeToUpdate)
    {
        if (newName != null && newName.Trim() != string.Empty)
                    RecipeToUpdate.Name = newName;
    }
    public void UpdatePreparationTime(double newPreparationTime, Recipe RecipeToUpdate)
    {
        if (newPreparationTime > 0)
                    RecipeToUpdate.PreparationTime = newPreparationTime;
    }
    public void UpdateDirections(string newDirections, Recipe RecipeToUpdate)
    {
        if (newDirections != null && newDirections.Trim() != string.Empty)
                    RecipeToUpdate.Directions = newDirections;
    }
    public void UpdateRating(int newRating, Recipe RecipeToUpdate)
    {
        if (newRating >= 0 && newRating <= 10)
                    RecipeToUpdate.Rating = newRating;
    }
    public void UpdateIngredients(List<string> newIngredients, InputRecipeDto RecipeToUpdate, int recipeId)
    {
        if (newIngredients != null && newIngredients.Count > 0)
                {
                    DeleteAllIngredients(recipeId);
                    foreach (var ingredient in newIngredients) _ingredientContext.AddIngredients(ingredient, recipeId);
                    RecipeToUpdate.Ingredients = newIngredients;
                }
    }
    public Recipe ConvertInputToOutputRecipe(InputRecipeDto item)
    {
        var toAdd = new Recipe
        {
            Name = item.Name,
            RecipeType = item.RecipeType,
            PreparationTime = item.PreparationTime,
            Directions = item.Directions,
            Rating = item.Rating
        };
        return toAdd;
    }
    public bool RecipeExists(string recipeId)
    {

        if (int.TryParse(recipeId, out int recipeIdInput))
        {
            if (_context.Recipes.Any(x => x.RecipeId == recipeIdInput))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Nao Encontrado");
                }
        }
        else
        {
            throw new Exception("Erro de conversao, preciso de um inteiro");
        }
    }

    public void ExceptionTryCatch(InputRecipeDto item)
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
        if (item.Ingredients == null || item.Ingredients.Count == 0)
        {
            throw new Exception("Ingredients are required");
        }
        if (item.Directions == null || item.Directions == "" || item.Directions == " " || item.Directions == string.Empty)
        {
            throw new Exception("Directions are required");
        }
    }

    
}