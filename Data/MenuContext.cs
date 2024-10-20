using Microsoft.EntityFrameworkCore;
using food_webapp_dotnet.Models;

namespace food_webapp_dotnet.Data
{
	public class MenuContext : DbContext
	{
		public MenuContext(DbContextOptions<MenuContext> options):base(options)  { }
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<DishIngredient>()
			.HasKey(di => new { di.DishId, di.IngredientId });
		modelBuilder.Entity<DishIngredient>()
			.HasOne(di => di.Dish)
			.WithMany(d => d.DishIngredients)
			.HasForeignKey(di => di.DishId);
		modelBuilder.Entity<DishIngredient>()
			.HasOne(di => di.Ingredient)
			.WithMany(i => i.DishIngredients)
			.HasForeignKey(di => di.IngredientId);
	}
}
