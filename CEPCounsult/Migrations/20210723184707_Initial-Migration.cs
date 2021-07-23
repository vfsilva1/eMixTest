using Microsoft.EntityFrameworkCore.Migrations;

namespace CEPCounsult.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CEP",
                columns: table => new
                {
                    CepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "char(9)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    UF = table.Column<string>(type: "char(2)", nullable: true),
                    Unidade = table.Column<long>(type: "bigint", nullable: false),
                    IBGE = table.Column<int>(type: "int", nullable: false),
                    GIA = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEP", x => x.CepID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CEP");
        }
    }
}
