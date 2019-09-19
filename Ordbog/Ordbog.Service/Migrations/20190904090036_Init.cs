using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordbog.Service.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Articles",
            //    columns: table => new
            //    {
            //        ArticleId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Word = table.Column<string>(nullable: false),
            //        Transcription = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Articles", x => x.ArticleId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Translations",
            //    columns: table => new
            //    {
            //        TranslationId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Text = table.Column<string>(nullable: false),
            //        ArticleId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Translations", x => x.TranslationId);
            //        table.ForeignKey(
            //            name: "FK_Translations_Articles_ArticleId",
            //            column: x => x.ArticleId,
            //            principalTable: "Articles",
            //            principalColumn: "ArticleId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Translations_ArticleId",
            //    table: "Translations",
            //    column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
