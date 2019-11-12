using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsNG.Migrations
{
    public partial class Part_PackageId_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Packages_PackageId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Parts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Packages_PackageId",
                table: "Parts",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Packages_PackageId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "Parts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Packages_PackageId",
                table: "Parts",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
