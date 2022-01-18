using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Advisor.Migrations
{
    public partial class UpdateUserIDFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Hotel_HotelID",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ReviewLike",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Review",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Favourite",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLike_UserID",
                table: "ReviewLike",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserID",
                table: "Review",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_HotelID",
                table: "Favourite",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_UserID",
                table: "Favourite",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourite_AspNetUsers_UserID",
                table: "Favourite",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourite_Hotel_HotelID",
                table: "Favourite",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_UserID",
                table: "Review",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Hotel_HotelID",
                table: "Review",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserID",
                table: "ReviewLike",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourite_AspNetUsers_UserID",
                table: "Favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourite_Hotel_HotelID",
                table: "Favourite");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_UserID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Hotel_HotelID",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewLike_AspNetUsers_UserID",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_ReviewLike_UserID",
                table: "ReviewLike");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserID",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Favourite_HotelID",
                table: "Favourite");

            migrationBuilder.DropIndex(
                name: "IX_Favourite_UserID",
                table: "Favourite");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "ReviewLike",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Favourite",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Hotel_HotelID",
                table: "Review",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
