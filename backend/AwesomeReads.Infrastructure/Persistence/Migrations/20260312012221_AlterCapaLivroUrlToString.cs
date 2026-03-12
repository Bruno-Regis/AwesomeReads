using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeReads.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterCapaLivroUrlToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "leitor",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CapaLivro",
                table: "Livros",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 5242880,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "leitor");

            migrationBuilder.AlterColumn<byte[]>(
                name: "CapaLivro",
                table: "Livros",
                type: "varbinary(max)",
                maxLength: 5242880,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
