using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthBasic.Migrations.Reddit
{
    public partial class what : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    subreddit = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    num_comments = table.Column<string>(nullable: true),
                    score = table.Column<string>(nullable: true),
                    created_utc = table.Column<double>(nullable: false),
                    created_string = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
