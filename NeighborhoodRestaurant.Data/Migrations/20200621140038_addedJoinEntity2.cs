using Microsoft.EntityFrameworkCore.Migrations;

namespace NeighborhoodRestaurant.Data.Migrations
{
    public partial class addedJoinEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "JoinTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "JoinTable",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
