using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)//[FromBody] a informação do filme vem do corpo da requisição, ou seja, do post que o usuario fez
        {
            filme.Id = id++;
            filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes() // IEnumerable é uma interface que herdada na classe list 
        {
            return filmes;
        }

        [HttpGet("{id}")]// a expressão "{id}" é a forma de passar o parâmetro id do método abaixo. O valor é passado dentro da URL ex.: https://localhost:7206/filme/1 . A url com /1 é a forma de saber que estamos utilizando o httpget com parâmetro
        public Filme RecuperaFilmePeloId(int id)
        {
            foreach(Filme filme in filmes)
            {
                if(filme.Id == id)
                {
                    return filme;
                }
            }
            return null;
        }
    }
}
