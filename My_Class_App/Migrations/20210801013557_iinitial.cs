using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Classes_App.Migrations
{
    public partial class iinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    HomeworkTypeId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.HomeworkTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkAssignments",
                columns: table => new
                {
                    HomeworkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 55, nullable: false),
                    PointValue = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    HomeworkTypeId = table.Column<string>(nullable: false),
                    StatusId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkAssignments", x => x.HomeworkId);
                    table.ForeignKey(
                        name: "FK_HomeworkAssignments_Sprints_HomeworkTypeId",
                        column: x => x.HomeworkTypeId,
                        principalTable: "Sprints",
                        principalColumn: "HomeworkTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkAssignments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sprints",
                columns: new[] { "HomeworkTypeId", "Name" },
                values: new object[,]
                {
                    { "assignment", "Assignment" },
                    { "quiz", "Quiz" },
                    { "test", "Test" },
                    { "groupproject", "Group Project" },
                    { "finalproject", "Final Project" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { "t", "To Do" },
                    { "i", "In progress" },
                    { "redo", "Redo" },
                    { "d", "Done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAssignments_HomeworkTypeId",
                table: "HomeworkAssignments",
                column: "HomeworkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkAssignments_StatusId",
                table: "HomeworkAssignments",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeworkAssignments");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
