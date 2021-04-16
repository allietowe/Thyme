using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Thyme1.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "ProgressPhotos",
               columns: table => new
               {
                   ProgressPhotoID = table.Column<int>(nullable: false)
                       .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                   Name = table.Column<string>(nullable: true),
                   PhotoName = table.Column<string>(type: "nvarchar(100)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ProgressPhotos", x => x.ProgressPhotoID);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
