using System.ComponentModel.DataAnnotations;
namespace L01_2021AR601_2021MM656.models
{
    public class comentarios
    {
        [Key]
        public int comentarioId { get; set; }
        public int publicacionId { get; set; }
        public string? comentario { get; set; }
        public int? usuarioId { get; set; }
        }
    }
}
