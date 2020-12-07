using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleForDNetFrameWork.Migrations
{
    public partial class _20190911 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RInfDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RInfID = table.Column<int>(nullable: false),
                    BookName = table.Column<string>(maxLength: 1000, nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Briefs = table.Column<string>(maxLength: 2000, nullable: true),
                    IsRented = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RInfDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RInfDetails_RentInfors_RInfID",
                        column: x => x.RInfID,
                        principalTable: "RentInfors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RInfDetails_RInfID",
                table: "RInfDetails",
                column: "RInfID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RInfDetails");
        }
    }
}
