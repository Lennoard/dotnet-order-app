using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetorderapp.Migrations
{
    /// <inheritdoc />
    public partial class Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsumidorId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PagamentoId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Pagamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ConsumidorId",
                table: "Pedidos",
                column: "ConsumidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_PedidoId",
                table: "Pagamentos",
                column: "PedidoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidoId",
                table: "Pagamentos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Consumidores_ConsumidorId",
                table: "Pedidos",
                column: "ConsumidorId",
                principalTable: "Consumidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Pedidos_PedidoId",
                table: "Pagamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Consumidores_ConsumidorId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ConsumidorId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_PedidoId",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "ConsumidorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PagamentoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Pagamentos");
        }
    }
}
