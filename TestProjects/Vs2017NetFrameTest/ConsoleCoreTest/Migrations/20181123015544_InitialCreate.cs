using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleCoreTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "UserInfors",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(maxLength: 32, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    addr = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    AddIdentity = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.Addresses_dbo.UserInfors_UserID",
                        column: x => x.UserID,
                        principalTable: "UserInfors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserID",
                table: "Addresses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UserNameUniqueIndex",
                table: "UserInfors",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "UserInfors");
        }
    }
}
