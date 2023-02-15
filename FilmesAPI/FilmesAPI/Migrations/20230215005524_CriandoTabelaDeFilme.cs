using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaDeFilme : Migration
    {

        /** CAMINHO PARA CRIAR A TABELA
                - Ferramentas -> Gerenciador de Pacotes do Nuget -> Console
                - No console rodar o comando: Add-Migration CriandoBandoDeDados
                - Depois que a classe CriandoBandoDeDados for criada
                - No concole rodar o comando para criar o banco: Update-Database 
                - Fim **/


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    Diretor = table.Column<string>(type: "longtext", nullable: false),
                    Genero = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
