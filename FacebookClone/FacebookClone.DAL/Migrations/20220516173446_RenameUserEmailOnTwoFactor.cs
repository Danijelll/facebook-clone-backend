using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacebookClone.DAL.Migrations
{
    public partial class RenameUserEmailOnTwoFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_email",
                schema: "dbo",
                table: "two_factor_authentication",
                newName: "user_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_name",
                schema: "dbo",
                table: "two_factor_authentication",
                newName: "user_email");
        }
    }
}
