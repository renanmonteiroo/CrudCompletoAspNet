using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuCrudCompleto.Migrations
{
    public partial class DepartamentoForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_Departamentoid",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Vendedor",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Departamentoid",
                table: "Vendedor",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_Departamentoid",
                table: "Vendedor",
                newName: "IX_Vendedor_DepartamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Vendedor",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Vendedor",
                newName: "Departamentoid");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DepartamentoId",
                table: "Vendedor",
                newName: "IX_Vendedor_Departamentoid");

            migrationBuilder.AlterColumn<int>(
                name: "Departamentoid",
                table: "Vendedor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_Departamentoid",
                table: "Vendedor",
                column: "Departamentoid",
                principalTable: "Departamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
