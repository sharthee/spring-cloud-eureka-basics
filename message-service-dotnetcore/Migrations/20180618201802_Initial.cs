using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quote = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Quote" },
                values: new object[] { 1, "Winston Churchill", "Never, never, never give up" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Quote" },
                values: new object[] { 2, "Marcus Tullius Cicero", "While there''s life, there''s hope" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Quote" },
                values: new object[] { 3, "Anonymous", "Failure is success in progress" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Quote" },
                values: new object[] { 4, "Vincent Lombardi", "Success demands singleness of purpose" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Quote" },
                values: new object[] { 5, "Lord Herbert", "The shortest answer is doing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
