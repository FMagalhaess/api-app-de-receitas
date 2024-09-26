namespace recipes_front_end.Dto
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string? Name { get; set; }

        public string? RecipeType { get; set; }

        public double PreparationTime { get; set; }

        public string? Directions { get; set; }

        public int Rating { get; set; }
    }
    public class InputRecipeDto
    {
        public int? RecipeId { get; set; }

        public string? Name { get; set; }

        public int RecipeType { get; set; }

        public double PreparationTime { get; set; }
        public List<string>? Ingredients { get; set; }

        public string? Directions { get; set; }

        public int Rating { get; set; }
    }
}