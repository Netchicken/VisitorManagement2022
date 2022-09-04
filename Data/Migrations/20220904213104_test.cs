using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorManagement.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeleteThis",
                table: "Visitor",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteThis",
                table: "Visitor");
        }
    }
}
