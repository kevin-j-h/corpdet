using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employees.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_hire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deptid = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emps", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emps");
        }
    }
}
