using Microsoft.EntityFrameworkCore.Migrations;

namespace NeighborhoodRestaurant.Data.Migrations
{
    public partial class addedMealPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Meals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Meals");
        }
    }
}
