using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinary.Slices.Application.Data.VeterinaryMigrations
{
    /// <inheritdoc />
    public partial class BaseEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    alternative_phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    identification = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    date_added_to_system = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    breed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "consultations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pet_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    annotations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_of = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    crated_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultations", x => x.id);
                    table.ForeignKey(
                        name: "FK_consultations_pets_pet_id",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owners_pets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    owner_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pet_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners_pets", x => x.id);
                    table.ForeignKey(
                        name: "FK_owners_pets_owners_owner_id",
                        column: x => x.owner_id,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_owners_pets_pets_pet_id",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultations_pet_id",
                table: "consultations",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "IX_owners_pets_owner_id",
                table: "owners_pets",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_owners_pets_pet_id",
                table: "owners_pets",
                column: "pet_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultations");

            migrationBuilder.DropTable(
                name: "owners_pets");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "pets");
        }
    }
}
