using recipes_api.Dto;
using recipes_api.Models;
using System.Collections.Generic;

namespace recipes_api;

public class Recipe
{
    public int RecipeId { get; set; }
    public string Name { get; set; }

    public RecipesType RecipeType { get; set; }

    public double PreparationTime { get; set; }

    public string Directions { get; set; }

    public int Rating { get; set; }

    public static implicit operator Recipe(InputRecipeDto v)
    {
        throw new NotImplementedException();
    }
}
