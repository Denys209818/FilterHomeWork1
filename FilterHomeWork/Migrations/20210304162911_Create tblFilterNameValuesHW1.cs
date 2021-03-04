using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FilterHomeWork.Migrations
{
    public partial class CreatetblFilterNameValuesHW1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFilterValuesHW1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilterValuesHW1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFilterNameValuesHW1",
                columns: table => new
                {
                    FilterNameId = table.Column<int>(type: "integer", nullable: false),
                    FilterValueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilterNameValuesHW1", x => new { x.FilterNameId, x.FilterValueId });
                    table.ForeignKey(
                        name: "FK_tblFilterNameValuesHW1_tblFilterNameHW1_FilterNameId",
                        column: x => x.FilterNameId,
                        principalTable: "tblFilterNameHW1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFilterNameValuesHW1_tblFilterValuesHW1_FilterValueId",
                        column: x => x.FilterValueId,
                        principalTable: "tblFilterValuesHW1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFilterNameValuesHW1_FilterValueId",
                table: "tblFilterNameValuesHW1",
                column: "FilterValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFilterNameValuesHW1");

            migrationBuilder.DropTable(
                name: "tblFilterValuesHW1");
        }
    }
}
