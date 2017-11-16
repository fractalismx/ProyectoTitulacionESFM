using SistemaEncuestas.Bussiness;
using SistemaEncuestas.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaEncuestas.APIControllers
{
    [RoutePrefix("api/Categoria")]
    public class CategoriaController : ApiController
    {
        CategoriaService categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        public CategoriaController():this(new CategoriaService())
        {

        }

        [HttpGet]
        [Route("Listar")]
        public List<Categoria> Listar()
        {
            return categoriaService.ListarTodo();
        }

        [HttpGet]
        [Route("PorId/{id}")]
        public Categoria PorId(int id)
        {
            return categoriaService.ObtenerPorId(id);
        }

        [HttpPost]
        [Route("Crear")]
        public void Crear(Categoria categoria)
        {
            categoriaService.Guardar(categoria);
        }

        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar(Categoria categoria)
        {
            categoriaService.Actualizar(categoria);
        }

        [HttpPost]
        [Route("Borrar")]
        public void Borrar(int id)
        {
            categoriaService.Eliminar(id);
        }

        [HttpGet]
        [Route("Prueba")]
        public string Prueba()
        {
            return "Hola mundo";
        }

    }
}
