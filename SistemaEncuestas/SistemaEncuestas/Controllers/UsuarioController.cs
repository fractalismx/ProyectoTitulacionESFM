using Microsoft.AspNet.Identity;
using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService service;

        public UsuarioController(UsuarioService service)
        {
            this.service = service;
        }

        public UsuarioController():this (new UsuarioService())
        {

        }
        // GET: Usuario
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Usuario> lista = service.ListarTodo();

            if (lista != null)
                return View(lista);

            return View(new List<Usuario>());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpGet]
        [Authorize(Roles ="Admin, User")]
        public ActionResult ListEncuestas()
        {
            string idUser = HttpContext.User.Identity.GetUserId();
            return View(service.ListarEncuestas(idUser));
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
        public ActionResult Create()
        {
            return View(new Usuario());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Usuario usuario)
        {
            if (service.Guardar(usuario))
                return RedirectToAction("Index");

            return View(usuario);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(Usuario usuario)
        {
            if (service.Actualizar(usuario))
                return RedirectToAction("Index");
            return View(usuario);
        }

        /*
        [Authorize(Roles ="Admin, User")]
        public ActionResult EncuestaContestada()
        {
            int
            return View();
        }

        
         * [HttpGet]
        [Authorize(Roles ="Usuario, Admin")]
        public ActionResult Responder(int id)
        {

            EncuestaViewModel preguntas = service.Contestar(id);
            return View(preguntas);
        }
         */
    }
}