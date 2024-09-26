using recipes_api.Dto;
using recipes_api.Models;

namespace recipes_api.Repositories
{
    public interface ICommentRepository
    {
        CommentDtoOutput CreateComment(Comment comment);
        List<CommentDtoOutput> GetComments(string recipeId);
        void ExceptionTryCatch(Comment comment);
    }
}