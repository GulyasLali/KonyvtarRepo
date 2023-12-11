using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealKonyvtar.Server.Migrations
{
    /// <inheritdoc />
    public partial class kolcsonzesmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kolcsonzes",
                columns: table => new
                {
                    OlvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonyvId = table.Column<int>(type: "int", nullable: false),
                    BringOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BringBack = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolcsonzes", x => new {x.OlvId,x.KonyvId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kolcsonzes");
        }
    }
}
