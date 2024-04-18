using recipes_api;
using recipes_api.Services;
using recipes_api.Models;
using recipes_api.Repositories;
using Microsoft.EntityFrameworkCore;

public class RecipeRepository : IRecipeRepository
{
    private readonly IRecipesContext _context;

    public RecipeRepository(IRecipesContext context)
    {
        _context = context;
    }

    public Recipe AddRecipe(Recipe item)
    {
        ExceptionTryCatch(item);
        _context.Recipes.Add(item);
        _context.SaveChanges();
        return item;
    }
    public List<Recipe> GetRecipes()
    {
        return _context.Recipes.ToList();
    }

    public void DeleteRecipe(string name)
    {
        if (!RecipeExists(name))
        {
            throw new Exception("Nao Encontrado");
        }
        var toRemove = _context.Recipes.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        _context.Recipes.Remove(toRemove);
        _context.SaveChanges();
    }
    public Recipe GetRecipe(string name)
    {
        Recipe recipeToReturn = _context.Recipes.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        if (recipeToReturn != null)
        {
            return recipeToReturn;
        }
        else
        {
            throw new Exception("Nao Encontrado");
        }
    }
    public bool RecipeExists(string name)
    {
        if (_context.Recipes.Any(x => x.Name.ToLower() == name.ToLower()))
        {
            return true;
        }
        else
        {
            throw new Exception("Nao Encontrado");
        }
    }
    public Recipe UpdateRecipe(Recipe item, string name)
    {
        var toUpdate = _context.Recipes.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        ExceptionTryCatch(item);
        if (toUpdate != null)
        {
            toUpdate.Name = item.Name;
            toUpdate.RecipeType = item.RecipeType;
            if (item.PreparationTime != 0) toUpdate.PreparationTime = item.PreparationTime;
            // toUpdate.Ingredients = item.Ingredients;
            toUpdate.Directions = item.Directions;
            if (item.Rating != 0) toUpdate.Rating = item.Rating;
            _context.SaveChanges();
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