namespace recipes_api.Dto
{
    public class CommentDtoOutput
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string RecipeName { get; set; }

    }
    
}