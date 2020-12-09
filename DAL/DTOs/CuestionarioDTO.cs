using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Covid19.DAL.DTOs
{
    public class CuestionarioDto
    {
        public int Operario { get; set; }

        [StringLength(100, ErrorMessage = "Se esperaba cadena de texto con un máximo de 120 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [StringLength(50, ErrorMessage = "Se esperaba cadena de texto con un máximo de 50 caracteres.")]
        public string Perfil { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [Display(Name = "¿Cuál es tu respuesta las preguntas anteriores?")]
        [StringLength(5, ErrorMessage = "Se esperaba cadena de texto con un máximo de 5 caracteres.")]
        public string Respuesta { get; set; }
    }
}
