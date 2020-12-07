using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleForDNetFrameWork.Migrations
{
    public partial class _201811260900 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentInfors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BookName = table.Column<string>(maxLength: 2000, nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Briefs = table.Column<string>(nullable: true),
                    RentDate = table.Column<DateTime>(type: "datetime", defaultValueSql: "(getdate())"),
                    IsRented = table.Column<bool>(defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentInfors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RentInfors_UserInfors_UserID",
                        column: x => x.UserID,
                        principalTable: "UserInfors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                        //,onUpdate : ReferentialAction.Cascade
                        );
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentInfors_UserID",
                table: "RentInfors",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "BookNameUniqueIndex_InRentInfors",
                table: "RentInfors",
                column: "BookName"
                , unique: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentInfors");
        }
    }
}
