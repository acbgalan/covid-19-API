using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Covid19.DAL.DTOs
{
    public class TomaTemperaturaDto
    {
        public string Temperatura { get; set; }
        public int Supervisor { get; set; }

        [StringLength(100, ErrorMessage = "Se esperaba cadena de texto con un máximo de 120 caracteres.")]
        public string SupervisorNombre { get; set; }

    }
}
