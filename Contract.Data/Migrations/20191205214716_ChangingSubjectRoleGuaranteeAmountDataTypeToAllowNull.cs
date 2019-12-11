using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract.Data.Migrations
{
    public partial class ChangingSubjectRoleGuaranteeAmountDataTypeToAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GuaranteeAmountValue",
                table: "SubjectRole",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "GuaranteeAmountCurrency",
                table: "SubjectRole",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GuaranteeAmountValue",
                table: "SubjectRole",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuaranteeAmountCurrency",
                table: "SubjectRole",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
