using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTree.Migrations
{
    public partial class FamilyCreatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Families",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Families_CreatorId",
                table: "Families",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Families_CreatorId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Families");
        }
    }
}
