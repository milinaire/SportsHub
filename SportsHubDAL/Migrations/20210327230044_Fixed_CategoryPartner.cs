using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class Fixed_CategoryPartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPartners_NewsPartners_NewsPartnerId",
                table: "CategoryPartners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryPartners",
                table: "CategoryPartners");

            migrationBuilder.DropIndex(
                name: "IX_CategoryPartners_NewsPartnerId",
                table: "CategoryPartners");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "CategoryPartners");

            migrationBuilder.AlterColumn<int>(
                name: "NewsPartnerId",
                table: "CategoryPartners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryPartners",
                table: "CategoryPartners",
                columns: new[] { "NewsPartnerId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPartners_NewsPartners_NewsPartnerId",
                table: "CategoryPartners",
                column: "NewsPartnerId",
                principalTable: "NewsPartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPartners_NewsPartners_NewsPartnerId",
                table: "CategoryPartners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryPartners",
                table: "CategoryPartners");

            migrationBuilder.AlterColumn<int>(
                name: "NewsPartnerId",
                table: "CategoryPartners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "CategoryPartners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryPartners",
                table: "CategoryPartners",
                columns: new[] { "PartnerId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPartners_NewsPartnerId",
                table: "CategoryPartners",
                column: "NewsPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPartners_NewsPartners_NewsPartnerId",
                table: "CategoryPartners",
                column: "NewsPartnerId",
                principalTable: "NewsPartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
