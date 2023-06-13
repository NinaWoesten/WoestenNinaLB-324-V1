using Microsoft.EntityFrameworkCore;
using WoestenNinaLB_295.Models;

public class RecipeContext : DbContext
{
    public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
    {
        
    }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredients> Ingredients { get; set; }



}