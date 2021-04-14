using Microsoft.EntityFrameworkCore.Migrations;

namespace BookEntities.Migrations
{
    public partial class BooksInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    PublicationYear = table.Column<long>(nullable: false),
                    BookDescription = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    BookImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
