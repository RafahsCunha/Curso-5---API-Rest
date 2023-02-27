using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext 
    {
        /** CAMINHO PARA CRIAR A TABELA
                - Ferramentas -> Gerenciador de Pacotes do Nuget -> Console
                - No console rodar o comando: Add-Migration CriandoBandoDeDados
                - Depois que a classe CriandoBandoDeDados for criada
                - No concole rodar o comando para criar o banco: Update-Database 
                - Fim **/
        public FilmeContext(DbContextOptions<FilmeContext> opt ) : base( opt) 
        {

        }

        public DbSet<Filme> Filmes { get; set; }


    }
}
