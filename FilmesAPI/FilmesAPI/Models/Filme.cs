using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key] 
        [Required] 
        public int Id { get; set; }

        [Required (ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }

        [Required (ErrorMessage = "Campo Diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30,ErrorMessage = "Genero nao pode passar de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600,ErrorMessage="Deve estar entre 1 e 600")]
        public int Duracao { get; set; }
    }
}
