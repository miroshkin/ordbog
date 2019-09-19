using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordbog.Service.Migrations
{
    public partial class ArticleForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Translations_Articles_ArticleId",
            //    table: "Translations");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ArticleId",
            //    table: "Translations",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Translations_Articles_ArticleId",
            //    table: "Translations",
            //    column: "ArticleId",
            //    principalTable: "Articles",
            //    principalColumn: "ArticleId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Articles_ArticleId",
                table: "Translations");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Translations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Articles_ArticleId",
                table: "Translations",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
