using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context; // Campo do tipo FilmeContext

        public FilmeController(FilmeContext context)// Construtor para inicializar o campo FilmeContext _context
        {
            _context = context; // será usado para guardar info no banco e tbm acessar essas infos
        }
        

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)//[FromBody] a informação do filme vem do corpo da requisição, ou seja, do post que o usuario fez
        {
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Diretor =   filmeDto.Diretor,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao,
            };
            _context.Filmes.Add(filme);// Adiciona filmes
            _context.SaveChanges();// Salva as alterações no banco de dados
            return CreatedAtAction(nameof(RecuperaFilmePeloId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes() // enumeravel de filme
        {
            return _context.Filmes; // Recupera filmes
        }

        [HttpGet("{id}")]// a expressão "{id}" é a forma de passar o parâmetro id do método abaixo. O valor é passado dentro da URL ex.: https://localhost:7206/filme/1 . A url com /1 é a forma de saber que estamos utilizando o httpget com parâmetro
        public IActionResult RecuperaFilmePeloId(int id) // IActionResult é uma interface de resultado de ação. Ex ok() e NotFound()
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); // Função lâmbida... Estudar
            if(filme != null)
            {
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Duracao = filme.Duracao,
                    Id = filme.Id,
                    HoraDaColsulta = DateTime.Now
                };
                return Ok(filmeDto);
            }
            return NotFound(); // Ação do IActionResult

        }

        [HttpPut("{id}")] // recebe o id do parâmetro abaixo
        public  IActionResult AtualizaFilme(int id, [FromBody] ReadFilmeDto filmeDto) // [FromBody] corpo da requisição
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            filme.Titulo = filmeDto.Titulo;
            filme.Genero = filmeDto.Genero;
            filme.Duracao = filmeDto.Duracao;
            filme.Diretor = filmeDto.Diretor;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]// detela pelo "id"
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
