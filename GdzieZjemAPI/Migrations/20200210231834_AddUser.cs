using Microsoft.EntityFrameworkCore.Migrations;

namespace GdzieZjemAPI.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityRestaurant_Restaurants_CityId",
                table: "CityRestaurant");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityRestaurant_RestaurantId",
                table: "CityRestaurant",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityRestaurant_Restaurants_RestaurantId",
                table: "CityRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityRestaurant_Restaurants_RestaurantId",
                table: "CityRestaurant");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CityRestaurant_RestaurantId",
                table: "CityRestaurant");

            migrationBuilder.AddForeignKey(
                name: "FK_CityRestaurant_Restaurants_CityId",
                table: "CityRestaurant",
                column: "CityId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
