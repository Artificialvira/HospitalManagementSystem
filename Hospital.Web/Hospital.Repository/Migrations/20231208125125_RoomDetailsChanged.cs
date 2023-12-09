using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RoomDetailsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomName",
                table: "Rooms",
                newName: "RoomNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Rooms",
                newName: "RoomName");
        }
    }
}
