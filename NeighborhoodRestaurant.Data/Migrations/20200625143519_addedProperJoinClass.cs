using Microsoft.EntityFrameworkCore.Migrations;

namespace NeighborhoodRestaurant.Data.Migrations
{
    public partial class addedProperJoinClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProperJoinTable",
                columns: table => new
                {
                    DayOfWeek = table.Column<int>(nullable: false),
                    MealName = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProperJoinTable");
        }
    }
}
