using recipes_api.Repositories;
namespace recipes_api.Repositories;
public class CommentRepository
{
    private readonly IRecipesContext _context;

    public CommentRepository(IRecipesContext context)
    {
        _context = context;
    }
}