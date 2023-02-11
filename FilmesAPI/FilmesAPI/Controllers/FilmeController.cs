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
        public IActionResult AdicionaFilme([FromBody] Filme filme)//[FromBody] a informação do filme vem do corpo da requisição, ou seja, do post que o usuario fez
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmePeloId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes() // IActionResult é uma interface de resultado de ação. Ex ok()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]// a expressão "{id}" é a forma de passar o parâmetro id do método abaixo. O valor é passado dentro da URL ex.: https://localhost:7206/filme/1 . A url com /1 é a forma de saber que estamos utilizando o httpget com parâmetro
        public IActionResult RecuperaFilmePeloId(int id) // IActionResult é uma interface de resultado de ação. Ex ok() e NotFound()
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id); // Função lâmbida... Estudar
            if(filme != null)
            {
                return Ok(filme);// Ação do IActionResult
            }
            return NotFound(); // Ação do IActionResult

        }
    }
}
