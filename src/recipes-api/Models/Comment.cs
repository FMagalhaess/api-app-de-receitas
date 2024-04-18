using recipes_api.Models;
using System.Collections.Generic;

namespace recipes_api;

public class Comment
{
    public int CommentId { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Email { get; set; }
    public string RecipeName { get; set; }
    public string CommentText { get; set; }
}