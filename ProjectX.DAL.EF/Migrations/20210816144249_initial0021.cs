using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectX.DAL.EF.Migrations
{
    public partial class initial0021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DDD",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DDD",
                table: "Students");
        }
    }
}
