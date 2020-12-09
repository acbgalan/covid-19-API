using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid19.DAL.Models
{
    public class Cuestionario
    {
        [Key]
        public int Id { get; set; }

        public int Operario { get; set; }

        [StringLength(100, ErrorMessage = "Se esperaba cadena de texto con un máximo de 120 caracteres.")]
        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [StringLength(50, ErrorMessage = "Se esperaba cadena de texto con un máximo de 50 caracteres.")]
        [Display(Name = "Perfil del empleado")]
        public string Perfil { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [Display(Name = "¿Cuál es tu respuesta las preguntas anteriores?")]
        [StringLength(5, ErrorMessage = "Se esperaba cadena de texto con un máximo de 5 caracteres.")]
        public string Respuesta { get; set; }

        public DateTime FechaRespuesta { get; set; }

        //Toma de temperatura
        public string Temperatura { get; set; }
        public DateTime? FechaTemperatura { get; set; }

        public int? Supervisor { get; set; }

        [StringLength(100, ErrorMessage = "Se esperaba cadena de texto con un máximo de 120 caracteres.")]
        public string SupervisorNombre { get; set; }
    }
}
