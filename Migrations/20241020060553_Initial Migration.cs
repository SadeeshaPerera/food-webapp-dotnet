﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace food_webapp_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/4QBeRXhpZgAASUkqAAgAAAACAA4BAgAqAAAAJgAAAJiCAgAGAAAAUAAAAAAAAABJdGFsaWFuIHBpenphIE1hcmdoZXJpdGEgb24gYSB3b29kZW4gdGFibGVWYW5rYUT/7QB+UGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAGIcAlAABlZhbmthRBwCeAAqSXRhbGlhbiBwaXp6YSBNYXJnaGVyaXRhIG9uIGEgd29vZGVuIHRhYmxlHAJ0AAZWYW5rYUQcAm4AGEdldHR5IEltYWdlcy9pU3RvY2twaG90b//hBTxodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+Cjx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iPgoJPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KCQk8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczpwaG90b3Nob3A9Imh0dHA6Ly9ucy5hZG9iZS5jb20vcGhvdG9zaG9wLzEuMC8iIHhtbG5zOklwdGM0eG1wQ29yZT0iaHR0cDovL2lwdGMub3JnL3N0ZC9JcHRjNHhtcENvcmUvMS4wL3htbG5zLyIgICB4bWxuczpHZXR0eUltYWdlc0dJRlQ9Imh0dHA6Ly94bXAuZ2V0dHlpbWFnZXMuY29tL2dpZnQvMS4wLyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpwbHVzPSJodHRwOi8vbnMudXNlcGx1cy5vcmcvbGRmL3htcC8xLjAvIiAgeG1sbnM6aXB0Y0V4dD0iaHR0cDovL2lwdGMub3JnL3N0ZC9JcHRjNHhtcEV4dC8yMDA4LTAyLTI5LyIgeG1sbnM6eG1wUmlnaHRzPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvcmlnaHRzLyIgZGM6UmlnaHRzPSJWYW5rYUQiIHBob3Rvc2hvcDpDcmVkaXQ9IkdldHR5IElt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", "Pizza", 10.99 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cheese" },
                    { 2, "Tomato" }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
