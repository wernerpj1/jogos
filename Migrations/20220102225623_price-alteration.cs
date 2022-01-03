using Microsoft.EntityFrameworkCore.Migrations;

namespace Jogos.Migrations
{
    public partial class pricealteration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TB_JOGO",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TB_JOGO");
        }
    }
}
