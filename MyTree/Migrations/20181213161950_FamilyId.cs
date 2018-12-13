using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTree.Migrations
{
    public partial class FamilyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "FamilyMembers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "FamilyMembers");
        }
    }
}
