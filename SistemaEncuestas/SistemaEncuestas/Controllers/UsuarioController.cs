using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace SistemaEncuestas.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService service;
        private ApplicationUserManager _userManager;

        public UsuarioController(UsuarioService service)
        {
            this.service = service;
        }

        public UsuarioController() : this(new UsuarioService())
        {

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Usuario
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Usuario> lista = service.ListarTodo();
            TempData["MyUser"] = false;

            if (lista != null)
                return View(lista);

            return View(new List<Usuario>());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            return View(service.ObtenerPorId(id));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult ListEncuestas()
        {
            string idUser = HttpContext.User.Identity.GetUserId();
            return View(service.ListarEncuestas(idUser));
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult DetalleEncuestas(int id)
        {
            string idUser = HttpContext.User.Identity.GetUserId();

            UsuarioEncuestaViewModel contestada = service.DetalleEncuestas(idUser, id);
            return View(contestada);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (service.Eliminar(id))
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                id = User.Identity.GetUserId();

            var user = service.ObtenerPorId(id);

            IEnumerable<Genero> GenderType = Enum.GetValues(typeof(Genero)).Cast<Genero>();

            user.ActionsList = from action in GenderType
                               select new SelectListItem
                               {
                                   Text = action.ToString(),
                                   Value = ((int)action).ToString()
                               };

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> Edit(Usuario usuario)
        {
            var user = UserManager.FindById(usuario.Id);

            IEnumerable<Genero> GenderType = Enum.GetValues(typeof(Genero)).Cast<Genero>();

            usuario.ActionsList = from action in GenderType
                                  select new SelectListItem
                                  {
                                      Text = action.ToString(),
                                      Value = ((int)action).ToString()
                                  };

            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    user.UserName = usuario.Email;
                    user.Email = usuario.Email;
                    user.Nombre = usuario.Nombre;
                    user.Apellidos = usuario.Apellidos;
                    user.Genero = usuario.Genero;

                    var result = await UserManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        if (User.IsInRole("Admin"))
                        {
                            var prueba = TempData["MyUserNow"].ToString();
                            if (Convert.ToBoolean(prueba))
                            {
                                return RedirectToAction("Index", "Manage");
                            }
                            else
                            {
                                return RedirectToAction("Index");
                            }
                        }
                        else if (User.IsInRole("User"))
                            return RedirectToAction("Index", "Manage");
                        else
                            return View(usuario);
                    }
                    else
                    {
                        return View(usuario);
                    }
                }
                else
                {
                    return View(usuario);
                }
            }
            else
            {
                return View(usuario);
            }
        }
    }
}