using recipes_api.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace recipes_api;

public class Ingredients
{
    public int IngredientsId { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public string Name { get; set; }
    
}
