using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealerAPI.Migrations
{
    /// <inheritdoc />
    public partial class segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Local",
                table: "Autos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id_Local",
                table: "Autos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id_Autos",
                keyValue: 1,
                column: "Id_Local",
                value: "Sucursal001");
        }
    }
}
