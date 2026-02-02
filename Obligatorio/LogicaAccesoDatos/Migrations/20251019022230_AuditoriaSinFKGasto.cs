using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AuditoriaSinFKGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorias_Gastos_GastoId",
                table: "Auditorias");

            migrationBuilder.DropIndex(
                name: "IX_Auditorias_GastoId",
                table: "Auditorias");

            migrationBuilder.DropColumn(
                name: "GastoId",
                table: "Auditorias");

            migrationBuilder.AddColumn<int>(
                name: "idGasto",
                table: "Auditorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idGasto",
                table: "Auditorias");

            migrationBuilder.AddColumn<int>(
                name: "GastoId",
                table: "Auditorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_GastoId",
                table: "Auditorias",
                column: "GastoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorias_Gastos_GastoId",
                table: "Auditorias",
                column: "GastoId",
                principalTable: "Gastos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
