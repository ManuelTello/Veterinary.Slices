using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinary.Slices.Application.Data.VeterinaryMigrations
{
    /// <inheritdoc />
    public partial class ChangedPetWeithToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "weight",
                table: "pets",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "weight",
                table: "pets",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
