using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract.Data.Migrations
{
    public partial class AddingSubjectRoleTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "InstallmentlAmountCurrency",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OriginalAmountCurrency",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalAmountValue",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OverdueBalanceCurrency",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OverdueBalanceValue",
                table: "ContractsData",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SubjectRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerCode = table.Column<string>(nullable: true),
                    RoleOfCustomer = table.Column<int>(nullable: false),
                    GuaranteeAmountValue = table.Column<decimal>(nullable: false),
                    GuaranteeAmountCurrency = table.Column<int>(nullable: false),
                    ContractId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectRole_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRole_ContractId",
                table: "SubjectRole",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectRole");

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
    }
}
