using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract.Data.Migrations
{
    public partial class AddingMoneyToContractData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentBalance_Currency",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalance_Value",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "InstallmentAmount_Currency",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InstallmentAmount_Value",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginalAmount_Currency",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalAmount_Value",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverdueBalance_Currency",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OverdueBalance_Value",
                table: "ContractsData",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentBalance_Currency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "CurrentBalance_Value",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "InstallmentAmount_Currency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "InstallmentAmount_Value",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OriginalAmount_Currency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OriginalAmount_Value",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OverdueBalance_Currency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OverdueBalance_Value",
                table: "ContractsData");
        }
    }
}
