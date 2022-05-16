using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacebookClone.DAL.Migrations
{
    public partial class AddNicknameOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                schema: "dbo",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                schema: "dbo",
                table: "user");
        }
    }
}
