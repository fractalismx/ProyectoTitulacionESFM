using Microsoft.AspNet.Identity;
using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class EncuestaController : Controller
    {
        EncuestaService encuestaService;
        PreguntaService preguntaService;
        RespuestaService respuestaService;
        RespuestaUsuarioService respuestaUsuarioService;
        UsuarioService usuarioService;

        public EncuestaController(EncuestaService encuestaService,
                                  PreguntaService preguntaService,
                                  RespuestaService respuestaService,
                                  RespuestaUsuarioService respuestaUsuarioService,
                                  UsuarioService usuarioService)
        {
            this.encuestaService = encuestaService;
            this.preguntaService = preguntaService;
            this.respuestaService = respuestaService;
            this.respuestaUsuarioService = respuestaUsuarioService;
            this.usuarioService = usuarioService;
        }

        public EncuestaController() :
            this(new EncuestaService(),
                  new PreguntaService(),
                  new RespuestaService(),
                  new RespuestaUsuarioService(),
                  new UsuarioService())
        {

        }

        // GET: Encuesta
        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            List<Encuesta> lista = encuestaService.ListarTodo();

            if (lista != null)
                return View(lista);

            return View(new List<Encuesta>());
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int id)
        {
            return View(encuestaService.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Encuesta encuesta)
        {
            int aux = encuesta.IdCategorias;
            if (encuestaService.Eliminar(encuesta.Id))
                return RedirectToAction("Details/" + aux, "Categoria");
            return View(encuesta);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(encuestaService.ObtenerPorId(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int id)
        {
            Encuesta e = new Encuesta { IdCategorias = id };

            return View(e);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Encuesta encuesta)
        {
            encuesta.Alta = DateTime.Now;

            if (encuestaService.Guardar(encuesta))
                return RedirectToAction("Details/" + encuesta.IdCategorias, "Categoria");

            return View(encuesta);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(encuestaService.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Encuesta encuesta)
        {
            if (encuestaService.Actualizar(encuesta))
                return RedirectToAction("Details/" + encuesta.IdCategorias, "Categoria");
            return View(encuesta);
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Responder(int id)
        {
            List<RespuestaUsuario> respuestaUsuario = 
                respuestaUsuarioService.ListarTodo()
                .Where(c => c.IdUsuario == User.Identity.GetUserId()).ToList();

            if (respuestaUsuario.Count > 0)
            {
                TempData["ErrorMessage"] = "Encuesta ya contestada";
                TempData["Status"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                EncuestaViewModel preguntas = encuestaService.CargarPreguntas(id);
                return View(preguntas);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Responder(List<RespuestaUsuario> respuestas)
        {
            string idUser = HttpContext.User.Identity.GetUserId();

            for (int i = 0; i < respuestas.Count; i++)
                respuestas[i].IdUsuario = idUser;

            bool guardar = respuestaUsuarioService.Guardar(respuestas);

            if (guardar)
            {
                TempData["ErrorMessage"] = "Encuesta constestada satisfactoriamente";
                TempData["Status"] = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                EncuestaViewModel preguntas = encuestaService.CargarPreguntas(respuestas[0].IdEncuesta);
                return View(preguntas);
            }
        }
    }
}