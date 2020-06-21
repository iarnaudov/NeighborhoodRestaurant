using Microsoft.EntityFrameworkCore.Migrations;

namespace NeighborhoodRestaurant.Data.Migrations
{
    public partial class mealsAndOrders_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Orders_OrderId",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_OrderId",
                table: "Meals",
                newName: "IX_Meals_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Orders_OrderId",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_OrderId",
                table: "Meal",
                newName: "IX_Meal_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Orders_OrderId",
                table: "Meal",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
