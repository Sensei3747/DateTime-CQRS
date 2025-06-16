using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DateTime.Migrations
{
    /// <inheritdoc />
    public partial class FinalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Is_Granted",
                table: "RolePermissions",
                newName: "IsGranted");

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "ProgramRegistration",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramRegistration_BranchId",
                table: "ProgramRegistration",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramRegistration_Branches_BranchId",
                table: "ProgramRegistration",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramRegistration_Branches_BranchId",
                table: "ProgramRegistration");

            migrationBuilder.DropIndex(
                name: "IX_ProgramRegistration_BranchId",
                table: "ProgramRegistration");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ProgramRegistration");

            migrationBuilder.RenameColumn(
                name: "IsGranted",
                table: "RolePermissions",
                newName: "Is_Granted");
        }
    }
}
