using SistemaEncuestas.Models.Domain;
using System.Collections.Generic;

namespace SistemaEncuestas.Models.ViewModels
{
    public class UsuarioEncuestaViewModel
    {
        public List<Pregunta> Preguntas { get; set; }
        public List<List<Respuesta>> Respuestas { get; set; }
        public List<RespuestaUsuario> RespuestaUsuario { get; set; }
    }
}