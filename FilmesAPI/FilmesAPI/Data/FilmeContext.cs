using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext // DbContex classe de conexão com Banco de Dados
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt ) : base( opt) // FilmeContext = Construtor, DbContextOptions<FilmeContext> = o que vamos usar dentro do contexto Dbcontextopcions. opt para as informações para o opt do construtor base
        {

        }

        public DbSet<Filme> Filmes { get; set; } // propriedade que acessa os dados do banco


    }
}
