using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.ViewModels
{
    public class EncuestaViewModel
    {
        public List<Pregunta> Preguntas { get; set; }
        public List<List<Respuesta>> Respuestas { get; set; }
    }
}