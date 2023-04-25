using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOB.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ContatoId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<long>(
                name: "Cep",
                table: "Enderecos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Telefone",
                table: "Contatos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Celular",
                table: "Contatos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ContatoId",
                table: "Enderecos",
                column: "ContatoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ContatoId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<int>(
                name: "Cep",
                table: "Enderecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");            

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Contatos",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Celular",
                table: "Contatos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ContatoId",
                table: "Enderecos",
                column: "ContatoId");
        }
    }
}
