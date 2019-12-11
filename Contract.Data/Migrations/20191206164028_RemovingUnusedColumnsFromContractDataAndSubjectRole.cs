using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract.Data.Migrations
{
    public partial class RemovingUnusedColumnsFromContractDataAndSubjectRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuaranteeAmountCurrency",
                table: "SubjectRole");

            migrationBuilder.DropColumn(
                name: "GuaranteeAmountValue",
                table: "SubjectRole");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceCurrency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "CurrentBalanceValue",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "InstallmentAmountValue",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "InstallmentlAmountCurrency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OriginalAmountCurrency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OriginalAmountValue",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OverdueBalanceCurrency",
                table: "ContractsData");

            migrationBuilder.DropColumn(
                name: "OverdueBalanceValue",
                table: "ContractsData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuaranteeAmountCurrency",
                table: "SubjectRole",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GuaranteeAmountValue",
                table: "SubjectRole",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentBalanceCurrency",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentBalanceValue",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InstallmentAmountValue",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstallmentlAmountCurrency",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginalAmountCurrency",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalAmountValue",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OverdueBalanceCurrency",
                table: "ContractsData",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OverdueBalanceValue",
                table: "ContractsData",
                nullable: true);
        }
    }
}
