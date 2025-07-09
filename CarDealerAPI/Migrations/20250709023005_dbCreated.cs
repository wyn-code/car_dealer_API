using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarDealerAPI.Migrations
{
    /// <inheritdoc />
    public partial class dbCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id_Marca);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeAuto",
                columns: table => new
                {
                    Id_Tipo_Auto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_autos = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeAuto", x => x.Id_Tipo_Auto);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id_Modelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id_Modelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_Id_Marca",
                        column: x => x.Id_Marca,
                        principalTable: "Marcas",
                        principalColumn: "Id_Marca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id_Autos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usado = table.Column<bool>(type: "bit", nullable: false),
                    EsCeroKM = table.Column<bool>(type: "bit", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Motor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año_Modelo = table.Column<int>(type: "int", nullable: false),
                    Id_Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Tipo_Auto = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Id_Modelo = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id_Autos);
                    table.ForeignKey(
                        name: "FK_Autos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autos_Modelos_Id_Modelo",
                        column: x => x.Id_Modelo,
                        principalTable: "Modelos",
                        principalColumn: "Id_Modelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autos_TiposDeAuto_Id_Tipo_Auto",
                        column: x => x.Id_Tipo_Auto,
                        principalTable: "TiposDeAuto",
                        principalColumn: "Id_Tipo_Auto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Vendido" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id_Marca", "Nombre_Marca" },
                values: new object[] { 1, "Toyota" });

            migrationBuilder.InsertData(
                table: "TiposDeAuto",
                columns: new[] { "Id_Tipo_Auto", "tipo_autos" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "SUV" },
                    { 3, "Pickup" },
                    { 4, "Coupé" },
                    { 5, "Hatchback" },
                    { 6, "Convertible" }
                });

            migrationBuilder.InsertData(
                table: "Modelos",
                columns: new[] { "Id_Modelo", "Id_Marca", "Nombre_Modelo" },
                values: new object[] { 1, 1, "Corolla" });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id_Autos", "Año_Modelo", "Descripcion", "Disponible", "EsCeroKM", "EstadoId", "Id_Local", "Id_Modelo", "Id_Tipo_Auto", "Marca", "Motor", "Precio", "Usado", "fecha_creacion" },
                values: new object[] { 1, 2019, "Toyota Corolla usado, excelente estado, único dueño.", true, false, 1, "Sucursal001", 1, 1, "Toyota", "1.8L 4 cilindros", 35000.0, true, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_EstadoId",
                table: "Autos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_Id_Modelo",
                table: "Autos",
                column: "Id_Modelo");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_Id_Tipo_Auto",
                table: "Autos",
                column: "Id_Tipo_Auto");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Id_Marca",
                table: "Modelos",
                column: "Id_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeAuto_tipo_autos",
                table: "TiposDeAuto",
                column: "tipo_autos",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "TiposDeAuto");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
