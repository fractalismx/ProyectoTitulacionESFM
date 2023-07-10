using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class PreguntaController : Controller
    {
        PreguntaService service;

        public PreguntaController(PreguntaService service)
        {
            this.service = service;
        }

        public PreguntaController():this (new PreguntaService())
        {

        }

        // GET: Pregunta
        [Authorize(Roles = "Admin, Usuario")]
        public ActionResult Index()
        {
            List<Pregunta> lista = service.ListarTodo();

            if (lista != null)
                return View(lista);

            return View(new List<Pregunta>());
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Usuario")]
        public ActionResult Details(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Encuesta encuesta)
        {
            int aux = encuesta.IdCategorias;
            if (service.Eliminar(encuesta.Id))
                return RedirectToAction("Details/" + aux, "Encuesta");
            return View(encuesta);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int id)
        {
            Pregunta p = new Pregunta { IdEncuestas=id};

            return View(p);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Pregunta pregunta)
        {
            if (service.Guardar(pregunta))
                return RedirectToAction("Details/" + pregunta.IdEncuestas, "Encuesta");

            return View(pregunta);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Pregunta pregunta)
        {
            if (service.Actualizar(pregunta))
                return RedirectToAction("Details/" + pregunta.IdEncuestas, "Encuesta");
            return View(pregunta);
        }
    }
}