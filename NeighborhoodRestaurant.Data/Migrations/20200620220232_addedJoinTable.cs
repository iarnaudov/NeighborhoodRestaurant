using Microsoft.EntityFrameworkCore.Migrations;

namespace NeighborhoodRestaurant.Data.Migrations
{
    public partial class addedJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_OrderId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "MealOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOrders", x => new { x.MealId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_MealOrders_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealOrders_OrderId",
                table: "MealOrders",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_OrderId",
                table: "Meals",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
