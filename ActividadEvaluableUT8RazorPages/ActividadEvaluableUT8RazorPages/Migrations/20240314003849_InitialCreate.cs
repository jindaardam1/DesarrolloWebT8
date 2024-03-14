using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActividadEvaluableUT8RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logia",
                columns: table => new
                {
                    logia_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logia", x => x.logia_id);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    creature_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    logia_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.creature_id);
                    table.ForeignKey(
                        name: "FK_Creature_Logia_logia_id",
                        column: x => x.logia_id,
                        principalTable: "Logia",
                        principalColumn: "logia_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mason",
                columns: table => new
                {
                    masone_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    logia_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mason", x => x.masone_id);
                    table.ForeignKey(
                        name: "FK_Mason_Logia_logia_id",
                        column: x => x.logia_id,
                        principalTable: "Logia",
                        principalColumn: "logia_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creature_logia_id",
                table: "Creature",
                column: "logia_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mason_logia_id",
                table: "Mason",
                column: "logia_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Mason");

            migrationBuilder.DropTable(
                name: "Logia");
        }
    }
}
