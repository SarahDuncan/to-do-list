using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace to_do_list.web.Migrations
{
    public partial class NewPropertyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "ToDoItemModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "ToDoItemModel");
        }
    }
}
