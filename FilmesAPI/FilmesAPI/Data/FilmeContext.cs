using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext // DbContex classe de conexão com Banco de Dados
    {
        /** CAMINHO PARA CRIAR A TABELA
                - Ferramentas -> Gerenciador de Pacotes do Nuget -> Console
                - No console rodar o comando: Add-Migration CriandoBandoDeDados
                - Depois que a classe CriandoBandoDeDados for criada
                - No concole rodar o comando para criar o banco: Update-Database 
                - Fim **/
        public FilmeContext(DbContextOptions<FilmeContext> opt ) : base( opt) // FilmeContext = Construtor, DbContextOptions<FilmeContext> = o que vamos usar dentro do contexto Dbcontextopcions. opt para as informações para o opt do construtor base
        {

        }

        public DbSet<Filme> Filmes { get; set; } // propriedade que acessa os dados do banco


    }
}
