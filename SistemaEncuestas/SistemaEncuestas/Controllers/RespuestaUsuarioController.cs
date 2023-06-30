using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class RespuestaUsuarioController : Controller
    {
        RespuestaUsuarioService service;

        public RespuestaUsuarioController(RespuestaUsuarioService service)
        {
            this.service = service;
        }

        public RespuestaUsuarioController():this (new RespuestaUsuarioService())
        {

        }

        // GET: Respuesta
        [Authorize(Roles = "Admin, User")]
        public ActionResult Index()
        {
            List<RespuestaUsuario> lista = service.ListarTodo();

            if (lista != null)
                return View(lista);

            return View(new List<RespuestaUsuario>());
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
        public ActionResult Create()
        {
            return View(new RespuestaUsuario());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(RespuestaUsuario respuesta)
        {
            if (service.Guardar(respuesta))
                return RedirectToAction("Index");

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
        public ActionResult Edit(RespuestaUsuario respuesta)
        {
            if (service.Actualizar(respuesta))
                return RedirectToAction("Index");
            return View(respuesta);
        }
    }
}