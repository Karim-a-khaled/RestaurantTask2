using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTask.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RestaurantTables_RestaurantTableId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_Restaurants_RestaurantId",
                table: "RestaurantTables");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_TableTypes_TableType_Id",
                table: "RestaurantTables");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantTables_TableType_Id",
                table: "RestaurantTables");

            migrationBuilder.AlterColumn<int>(
                name: "TableType_Id",
                table: "RestaurantTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "RestaurantTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantTableId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTables_TableType_Id",
                table: "RestaurantTables",
                column: "TableType_Id",
                unique: true,
                filter: "[TableType_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RestaurantTables_RestaurantTableId",
                table: "Reservations",
                column: "RestaurantTableId",
                principalTable: "RestaurantTables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_Restaurants_RestaurantId",
                table: "RestaurantTables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_TableTypes_TableType_Id",
                table: "RestaurantTables",
                column: "TableType_Id",
                principalTable: "TableTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RestaurantTables_RestaurantTableId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_Restaurants_RestaurantId",
                table: "RestaurantTables");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_TableTypes_TableType_Id",
                table: "RestaurantTables");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantTables_TableType_Id",
                table: "RestaurantTables");

            migrationBuilder.AlterColumn<int>(
                name: "TableType_Id",
                table: "RestaurantTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "RestaurantTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantTableId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTables_TableType_Id",
                table: "RestaurantTables",
                column: "TableType_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RestaurantTables_RestaurantTableId",
                table: "Reservations",
                column: "RestaurantTableId",
                principalTable: "RestaurantTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_Restaurants_RestaurantId",
                table: "RestaurantTables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_TableTypes_TableType_Id",
                table: "RestaurantTables",
                column: "TableType_Id",
                principalTable: "TableTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
