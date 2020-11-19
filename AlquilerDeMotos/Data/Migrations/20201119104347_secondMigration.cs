using Microsoft.EntityFrameworkCore.Migrations;

namespace MotorcycleRent.Data.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Motorcycle");

            migrationBuilder.AlterColumn<int>(
                name: "Km",
                table: "Motorcycle",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Cc",
                table: "Motorcycle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Hp",
                table: "Motorcycle",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Motorcycle",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Rented",
                table: "Motorcycle",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Motorcycle",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cc",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "Hp",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "Rented",
                table: "Motorcycle");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Motorcycle");

            migrationBuilder.AlterColumn<double>(
                name: "Km",
                table: "Motorcycle",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Motorcycle",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
