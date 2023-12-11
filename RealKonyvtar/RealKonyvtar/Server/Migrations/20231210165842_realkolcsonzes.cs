using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealKonyvtar.Server.Migrations
{
    /// <inheritdoc />
    public partial class realkolcsonzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kolcsonzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OlvId = table.Column<int>(type: "int", nullable: false),
                    KonyvId = table.Column<int>(type: "int", nullable: false),
                    BringOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BringBack = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolcsonzes", x => x.Id);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
