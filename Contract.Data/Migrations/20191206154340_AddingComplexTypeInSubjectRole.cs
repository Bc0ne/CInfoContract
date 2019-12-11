using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract.Data.Migrations
{
    public partial class AddingComplexTypeInSubjectRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GuranateeAmountId",
                table: "SubjectRole",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(nullable: true),
                    Currency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRole_GuranateeAmountId",
                table: "SubjectRole",
                column: "GuranateeAmountId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectRole_Money_GuranateeAmountId",
                table: "SubjectRole",
                column: "GuranateeAmountId",
                principalTable: "Money",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectRole_Money_GuranateeAmountId",
                table: "SubjectRole");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropIndex(
                name: "IX_SubjectRole_GuranateeAmountId",
                table: "SubjectRole");

            migrationBuilder.DropColumn(
                name: "GuranateeAmountId",
                table: "SubjectRole");
        }
    }
}
