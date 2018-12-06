using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTree.Migrations
{
    public partial class Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Address_AddressId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FamilyMembers");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "FamilyMembers",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_AddressId",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "ParentOneId",
                table: "FamilyMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentTwoId",
                table: "FamilyMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "FamilyMembers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_ParentOneId",
                table: "FamilyMembers",
                column: "ParentOneId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_ParentTwoId",
                table: "FamilyMembers",
                column: "ParentTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_PartnerId",
                table: "FamilyMembers",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_People_ParentOneId",
                table: "FamilyMembers",
                column: "ParentOneId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_People_ParentTwoId",
                table: "FamilyMembers",
                column: "ParentTwoId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_People_PartnerId",
                table: "FamilyMembers",
                column: "PartnerId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_People_PersonId",
                table: "FamilyMembers",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_People_ParentOneId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_People_ParentTwoId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_People_PartnerId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_People_PersonId",
                table: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_ParentOneId",
                table: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_ParentTwoId",
                table: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_PartnerId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "ParentOneId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "ParentTwoId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "FamilyMembers");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "FamilyMembers",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_PersonId",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_AddressId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FamilyMembers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FamilyMembers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Address_AddressId",
                table: "FamilyMembers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
