using Microsoft.AspNet.Identity;
using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models;
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
        EncuestaService service;
        PreguntaService preguntaService;
        RespuestaService respuestaService;
        RespuestaUsuarioService respuestaUsuarioService;
        UsuarioService usuarioService;
        public EncuestaController(EncuestaService service,
                                  PreguntaService preguntaService,
                                  RespuestaService respuestaService,
                                  RespuestaUsuarioService respuestaUsuarioService,
                                  UsuarioService usuarioService)
        {
            this.service = service;
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
        public ActionResult Index()
        {
            List<Encuesta> lista = service.ListarTodo();

            if (lista != null)
                return View(lista);

            return View(new List<Encuesta>());
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
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
                return RedirectToAction("Details/" + aux, "Categoria");
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
            Encuesta e = new Encuesta { IdCategorias = id };

            return View(e);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Encuesta encuesta)
        {
            encuesta.Alta = DateTime.Now;

            if (service.Guardar(encuesta))
                return RedirectToAction("Details/" + encuesta.IdCategorias, "Categoria");

            return View(encuesta);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Encuesta encuesta)
        {
            if (service.Actualizar(encuesta))
                return RedirectToAction("Details/" + encuesta.IdCategorias, "Categoria");
            return View(encuesta);
        }

        [HttpGet]
        [Authorize(Roles = "Usuario, Admin")]
        public ActionResult Responder(int id)
        {        
            List <RespuestaUsuario> respuestaUsuario = respuestaUsuarioService.ListarTodo().Where(c => c.IdUsuario == User.Identity.GetUserId()).ToList();
            
            if (respuestaUsuario.Count > 0)
            {
                TempData["ErrorMessage"] = "Encuesta ya contestada";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                EncuestaViewModel preguntas = service.CargarPreguntas(id);
                ViewBag.User = User.Identity.GetUserId();
                return View(preguntas);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Responder(List<RespuestaUsuario> respuestas)
        {
            bool guardar = respuestaUsuarioService.Guardar(respuestas);

            if (guardar)
                return RedirectToAction("Index", "Home");
            else 
            {
                EncuestaViewModel preguntas = service.CargarPreguntas(respuestas[0].IdEncuesta);
                ViewBag.User = User.Identity.GetUserId();
                return View(preguntas);
            }
        }
    }
}