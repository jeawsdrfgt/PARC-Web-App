using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PARC_Web_App.Migrations
{
    public partial class SecondCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "AspNetUsers");
        }
    }
}
