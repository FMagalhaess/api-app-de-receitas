using recipes_api.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace recipes_api;

public class Ingredient
{
    public int IngredientId { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public string Name { get; set; }
    
}
