using Microsoft.EntityFrameworkCore;
using food_webapp_dotnet.Models;

namespace food_webapp_dotnet.Data
{
	public class MenuContext : DbContext
	{
		public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DishIngredient>()
				.HasKey(di => new { di.DishId, di.IngredientId });
			modelBuilder.Entity<DishIngredient>()
				.HasOne(di => di.Dish)
				.WithMany(d => d.DishIngredients)
				.HasForeignKey(di => di.DishId);
			modelBuilder.Entity<DishIngredient>()
				.HasOne(i => i.Ingredient)
				.WithMany(di => di.DishIngredients)
				.HasForeignKey(i => i.IngredientId);
			modelBuilder.Entity<Dish>().HasData(
				new Dish { Id = 1, Name = "Pizza", Price = 10.99, ImageUrl = "https://images.pexels.com/photos/33109/fall-autumn-red-season.jpg?auto=compress&cs=tinysrgb&w=600" }
				
			);
			modelBuilder.Entity<Ingredient>().HasData(
				new Ingredient { Id = 1, Name = "Cheese" },
				new Ingredient { Id = 2, Name = "Tomato" }
				
			);
			modelBuilder.Entity<DishIngredient>().HasData(
				new DishIngredient { DishId = 1, IngredientId = 1 },
				new DishIngredient { DishId = 1, IngredientId = 2 }

			);

			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<DishIngredient> DishIngredients { get; set; }
	}
}
