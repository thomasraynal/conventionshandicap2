using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class fixSchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CertificateDemandStatus",
                table: "ConventionsHandicapCertificateDemand",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CertificateDemandStatus",
                table: "ConventionsHandicapCertificateDemand",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
