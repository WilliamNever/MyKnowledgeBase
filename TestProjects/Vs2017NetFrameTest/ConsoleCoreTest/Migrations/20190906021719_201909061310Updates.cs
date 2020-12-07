using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleCoreTest.Migrations
{
    public partial class _201909061310Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.InsertData("UserInfors", new string[] { "id", "UserName", "Password", "LoginDate" },
                new object[,] {
                    {1,"aaa","aaa",DateTime.Now.ToString() },
                    {2,"bbb","bbb",DateTime.Now.ToString() },
                    {3,"ccc","ccc",DateTime.Now.ToString() },
                    {4,"ddd","ddd",DateTime.Now.ToString() },
                    {5,"eee","eee",DateTime.Now.ToString() }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("UserInfors", "id", new object[] { 1, 2, 3, 4, 5 });
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
        }
    }
}
