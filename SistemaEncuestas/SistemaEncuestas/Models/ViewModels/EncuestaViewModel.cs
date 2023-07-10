using SistemaEncuestas.Models.Domain;
using System.Collections.Generic;

namespace SistemaEncuestas.Models.ViewModels
{
    public class EncuestaViewModel
    {
        public List<Pregunta> Preguntas { get; set; }
        public List<List<Respuesta>> Respuestas { get; set; }
    }
}