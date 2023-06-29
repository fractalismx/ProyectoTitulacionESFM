using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SistemaEncuestas.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaService service;

        public CategoriaController(CategoriaService service)
        {
            this.service = service;
        }

        public CategoriaController() : this(new CategoriaService())
        {

        }

        // GET: Categoria
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Categoria> lista = service.ListarTodo();

            if (lista != null)
                return View(lista);

            return View(new List<Categoria>());
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetCategorias()
        {
            List<Categoria> list = service.ListarTodo() ?? new List<Categoria>();
            var listaAcomodada = list.OrderBy(c => c.Nombre).Select(c => new { id = c.Id, texto = c.Nombre });
            return Json(listaAcomodada, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Categoria categoria)
        {
            if (service.Eliminar(categoria.Id))
                return RedirectToAction("Index");
            return View(categoria);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Categoria());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Categoria categoria)
        {
            if (service.Guardar(categoria))
                return RedirectToAction("Index");

            return View(categoria);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Categoria categoria)
        {
            if (service.Actualizar(categoria))
                return RedirectToAction("Index");
            return View(categoria);
        }
    }
}