using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeReads.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfigCapaImgAsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "CapaLivro",
                table: "Livros",
                type: "varbinary(max)",
                maxLength: 5242880,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 5242880);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "CapaLivro",
                table: "Livros",
                type: "varbinary(max)",
                maxLength: 5242880,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 5242880,
                oldNullable: true);
        }
    }
}
