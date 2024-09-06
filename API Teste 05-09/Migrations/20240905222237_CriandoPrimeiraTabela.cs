using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Teste_05_09.Migrations
{
    /// <inheritdoc />
    public partial class CriandoPrimeiraTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespostaPergunta1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespostaPergunta2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpcionalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpcionalSugestao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionario", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questionario");
        }
    }
}
