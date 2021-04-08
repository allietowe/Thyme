using Microsoft.EntityFrameworkCore.Migrations;

namespace Thyme1.Migrations
{
    public partial class ProgressPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantRooms_PlantRoomId",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "PlantRoomId",
                table: "Plants",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgressPhoto",
                table: "Plants",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantRooms_PlantRoomId",
                table: "Plants",
                column: "PlantRoomId",
                principalTable: "PlantRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_PlantRooms_PlantRoomId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "ProgressPhoto",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "PlantRoomId",
                table: "Plants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_PlantRooms_PlantRoomId",
                table: "Plants",
                column: "PlantRoomId",
                principalTable: "PlantRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
