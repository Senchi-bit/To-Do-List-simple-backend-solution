using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskStateToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "task_state",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "task_state",
                table: "tasks");
        }
    }
}
