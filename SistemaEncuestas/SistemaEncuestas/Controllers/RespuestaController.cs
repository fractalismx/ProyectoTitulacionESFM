using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class RespuestaController : Controller
    {
        RespuestaService service;

        public RespuestaController(RespuestaService service)
        {
            this.service = service;
        }

        public RespuestaController() : this(new RespuestaService())
        {

        }

        // GET: Respuesta
        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            List<Respuesta> lista = service.ListarTodo();

            if (lista != null)
                return View(lista);

            return View(new List<Respuesta>());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (service.Eliminar(id))
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int id)
        {
            Respuesta respuesta = new Respuesta();

            respuesta.IdPreguntas = id;
            return View(respuesta);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Respuesta respuesta)
        {
            if (service.Guardar(respuesta))
                return RedirectToAction("Details/" + respuesta.IdPreguntas, "Pregunta");

            return View(respuesta);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Respuesta respuesta)
        {
            if (service.Actualizar(respuesta))
                return RedirectToAction("Details/" + respuesta.IdPreguntas, "Pregunta");
            return View(respuesta);
        }
    }
}