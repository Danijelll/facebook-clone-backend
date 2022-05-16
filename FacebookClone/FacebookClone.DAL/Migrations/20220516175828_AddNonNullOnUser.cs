using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacebookClone.DAL.Migrations
{
    public partial class AddNonNullOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "not_null_property",
                schema: "dbo",
                table: "user",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "Album");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "not_null_property",
                schema: "dbo",
                table: "user");
        }
    }
}
