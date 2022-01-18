using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Advisor.Migrations
{
    public partial class UpdateHotelUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Hotel",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_UserID",
                table: "Hotel",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_AspNetUsers_UserID",
                table: "Hotel",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_AspNetUsers_UserID",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_UserID",
                table: "Hotel");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Hotel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
