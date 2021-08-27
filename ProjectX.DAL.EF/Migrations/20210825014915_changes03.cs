using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectX.DAL.EF.Migrations
{
    public partial class changes03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PNGName",
                table: "Specializations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PNGName",
                table: "Specializations");
        }
    }
}
