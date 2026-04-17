using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebitosTributarios.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAtributoAnoReferenciaDesnecessario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoReferencia",
                table: "Debitos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnoReferencia",
                table: "Debitos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
