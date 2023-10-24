using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantTask.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantTables_TableTypes_TableType_Id",
                table: "RestaurantTables");

            migrationBuilder.DropTable(
                name: "TableTypes");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantTables_TableType_Id",
                table: "RestaurantTables");

            migrationBuilder.DropColumn(
                name: "TableType_Id",
                table: "RestaurantTables");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "RestaurantTables",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isIndoor",
                table: "RestaurantTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isLounge",
                table: "RestaurantTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isOutdoor",
                table: "RestaurantTables",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RestaurantTables");

            migrationBuilder.DropColumn(
                name: "isIndoor",
                table: "RestaurantTables");

            migrationBuilder.DropColumn(
                name: "isLounge",
                table: "RestaurantTables");

            migrationBuilder.DropColumn(
                name: "isOutdoor",
                table: "RestaurantTables");

            migrationBuilder.AddColumn<int>(
                name: "TableType_Id",
                table: "RestaurantTables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TableTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTables_TableType_Id",
                table: "RestaurantTables",
                column: "TableType_Id",
                unique: true,
                filter: "[TableType_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantTables_TableTypes_TableType_Id",
                table: "RestaurantTables",
                column: "TableType_Id",
                principalTable: "TableTypes",
                principalColumn: "Id");
        }
    }
}
