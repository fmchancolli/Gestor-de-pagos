using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_manager.Migrations
{
    public partial class AddSaldoPendienteToVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SaldoPendiente",
                table: "Ventas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoPendiente",
                table: "Ventas");
        }
    }
}
