using Microsoft.EntityFrameworkCore;
using recipes_api.Models;
namespace recipes_api.Repositories
{
    public interface IRecipesContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public int SaveChanges();
    }
}