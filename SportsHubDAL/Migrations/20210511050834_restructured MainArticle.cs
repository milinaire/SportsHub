using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class restructuredMainArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainArticles_Articles_ArticleId",
                table: "MainArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainArticles",
                table: "MainArticles");

            migrationBuilder.DropIndex(
                name: "IX_MainArticles_ArticleId",
                table: "MainArticles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MainArticles");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "MainArticles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainArticles",
                table: "MainArticles",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainArticles_Articles_ArticleId",
                table: "MainArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainArticles_Articles_ArticleId",
                table: "MainArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainArticles",
                table: "MainArticles");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "MainArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MainArticles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainArticles",
                table: "MainArticles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MainArticles_ArticleId",
                table: "MainArticles",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainArticles_Articles_ArticleId",
                table: "MainArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
