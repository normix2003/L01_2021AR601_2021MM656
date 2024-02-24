using System.ComponentModel.DataAnnotations;
namespace L01_2021AR601_2021MM656.models
{
    public class calificaciones
    {
        [Key]
        public int calificacionId { get; set; }
        public int? publicacionId { get; set; }
        public int? usuarioId { get; set; }
        public int? calificacion { get; set; }
        
    }
}
