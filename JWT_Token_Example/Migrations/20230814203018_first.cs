using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication_Login.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "RegistrationUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsModified = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RegistrationUser",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Document", "EmailAddress", "IsDeleted", "IsModified", "LastName", "ModifiedDate", "Name", "Password", "UserName" },
                values: new object[] { 1, "", new DateTime(2023, 8, 14, 16, 30, 18, 70, DateTimeKind.Local).AddTicks(8520), "40324251", "admin@gmail.com", false, false, "Admin", new DateTime(2023, 8, 14, 16, 30, 18, 70, DateTimeKind.Local).AddTicks(8536), "Admin", "123qwe", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationUser",
                schema: "dbo");
        }
    }
}
