using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleEntity.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Iss_Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iss_Position", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IssDbPositions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iss_PositionID = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssDbPositions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IssDbPositions_Iss_Position_Iss_PositionID",
                        column: x => x.Iss_PositionID,
                        principalTable: "Iss_Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssDbPositions_Iss_PositionID",
                table: "IssDbPositions",
                column: "Iss_PositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssDbPositions");

            migrationBuilder.DropTable(
                name: "Iss_Position");
        }
    }
}
