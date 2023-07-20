using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCIspit.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_task_todoList_TodoId",
                table: "task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todoList",
                table: "todoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_task",
                table: "task");

            migrationBuilder.RenameTable(
                name: "todoList",
                newName: "TodoList");

            migrationBuilder.RenameTable(
                name: "task",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_task_TodoId",
                table: "Task",
                newName: "IX_Task_TodoId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TodoList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TodoList_TodoId",
                table: "Task",
                column: "TodoId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TodoList_TodoId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TodoList");

            migrationBuilder.RenameTable(
                name: "TodoList",
                newName: "todoList");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "task");

            migrationBuilder.RenameIndex(
                name: "IX_Task_TodoId",
                table: "task",
                newName: "IX_task_TodoId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "todoList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_todoList",
                table: "todoList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_task",
                table: "task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_task_todoList_TodoId",
                table: "task",
                column: "TodoId",
                principalTable: "todoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
