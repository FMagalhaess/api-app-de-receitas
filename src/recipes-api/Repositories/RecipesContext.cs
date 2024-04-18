using Microsoft.EntityFrameworkCore;
namespace recipes_api.Repositories;
public class RecipesContext : DbContext, IRecipesContext
{
    public RecipesContext()
    {
    }

    public RecipesContext(DbContextOptions<RecipesContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Ingredients> Ingredients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=recipes-api;User=sa;Password=SqlServer123!;TrustServerCertificate=True;");
        }
    }

}