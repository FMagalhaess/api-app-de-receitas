using recipes_api.Repositories;
using recipes_api.Models;
using recipes_api.Dto;
using recipes_api.Services;
namespace recipes_api.Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly IRecipesContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IRecipeRepository _recipeRepository;

    public CommentRepository(IRecipesContext context, IUserRepository userRepository, IRecipeRepository recipeRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _recipeRepository = recipeRepository;
    }
    public CommentDtoOutput CreateComment(Comment comment)
    {   
        User UserFinded = _userRepository.GetUser(comment.Email);
        comment.UserId = UserFinded.UserId;
        InputRecipeDto RecipeFinded = _recipeRepository.GetRecipeById(comment.RecipeId);
        comment.RecipeName = RecipeFinded.Name;
        _context.Comments.Add(comment);
        _context.SaveChanges();
        CommentDtoOutput commentDto = ConvertCommentToDto(comment);
        return commentDto;
    }
    public List<CommentDtoOutput> GetComments(string recipeId)
    {
        int.TryParse(recipeId, out int id);
        List<CommentDtoOutput> toReturn = (from comment in _context.Comments
                                            where comment.RecipeId == id
                                            select new CommentDtoOutput
                                            {
                                                CommentId = comment.CommentId,
                                                CommentText = comment.CommentText,
                                                RecipeId = comment.RecipeId,
                                                UserId = comment.UserId,
                                                RecipeName = comment.RecipeName
                                            }).ToList();
        return toReturn;
    }
    public CommentDtoOutput ConvertCommentToDto(Comment comment)
    {
        return new CommentDtoOutput
        {
            CommentId = comment.CommentId,
            CommentText = comment.CommentText,
            RecipeId = comment.RecipeId,
            UserId = comment.UserId,
            RecipeName = comment.RecipeName
        };
    }
    public void ExceptionTryCatch(Comment comment)
    {
        if (comment == null)
        {
            throw new Exception("Comentário não pode ser nulo.");
        }
        if (string.IsNullOrEmpty(comment.CommentText))
        {
            throw new Exception("Comentário não pode ser vazio.");
        }
        if (comment.RecipeId == 0)
        {
            throw new Exception("Comentário deve estar associado a uma receita.");
        }
    }
}