using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DateTime.Migrations
{
    /// <inheritdoc />
    public partial class New_Db3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Branches_BranchId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_BranchId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Branches_BranchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BranchId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_BranchId",
                table: "Roles",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Branches_BranchId",
                table: "Roles",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
