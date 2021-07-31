using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Classes_App.Migrations
{
    public partial class maybefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 6,
                columns: new[] { "ClassTypeId", "NumberOfCredits" },
                values: new object[] { "computerscience", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 6,
                columns: new[] { "ClassTypeId", "NumberOfCredits" },
                values: new object[] { "computerscience ", 3 });
        }
    }
}
