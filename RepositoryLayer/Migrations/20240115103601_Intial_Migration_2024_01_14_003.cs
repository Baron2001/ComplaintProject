using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class Intial_Migration_2024_01_14_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaint_Department_DepartmentId",
                table: "Complaint");

            migrationBuilder.DropIndex(
                name: "IX_Complaint_DepartmentId",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Complaint");

            migrationBuilder.AddColumn<string>(
                name: "AssignUsersId",
                table: "Complaint",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignUsersId",
                table: "Complaint");

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "Complaint",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_DepartmentId",
                table: "Complaint",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaint_Department_DepartmentId",
                table: "Complaint",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
