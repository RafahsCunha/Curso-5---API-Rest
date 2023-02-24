using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    
    // Classe Dto - Data Transfer object . 
    // Classe responsável por transferir os dados entre as partes do sistema
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo Título é obrigatório")]// Indica que o Titulo é um campo obrigatório. ErrorMessage define qual será a mensagem de erro exibida
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Diretor é obrigatório")]// Indica que o Diretor é um campo obrigatório
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "Genero nao pode passar de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "Deve estar entre 1 e 600")]// Indica que filme pode durar no minimo 1 e no máximo 600
        public int Duracao { get; set; }
    }
}
  