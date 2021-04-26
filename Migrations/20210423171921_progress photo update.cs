using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Thyme1.Migrations
{
    public partial class progressphotoupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "ProgressPhotos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Taken",
                table: "ProgressPhotos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ProgressPhotos_PlantId",
                table: "ProgressPhotos",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressPhotos_Plants_PlantId",
                table: "ProgressPhotos",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressPhotos_Plants_PlantId",
                table: "ProgressPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ProgressPhotos_PlantId",
                table: "ProgressPhotos");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "ProgressPhotos");

            migrationBuilder.DropColumn(
                name: "Taken",
                table: "ProgressPhotos");
        }
    }
}
