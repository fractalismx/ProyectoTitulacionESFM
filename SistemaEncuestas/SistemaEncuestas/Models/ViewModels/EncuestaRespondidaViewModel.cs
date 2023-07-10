using SistemaEncuestas.Models.Domain;
using System.Collections.Generic;

namespace SistemaEncuestas.Models.ViewModels
{
    public class EncuestaRespondidaViewModel
    {
        public List<Respuesta> Respuestas{get;set;}
        public List<Pregunta> Preguntas { get; set; }
        public List<Encuesta> Encuestas { get; set; }
    }
}