using Microsoft.AspNet.Identity;
using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository;
using SistemaEncuestas.Models.Repository.Entity;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Bussiness
{
    public class RespuestaUsuarioService
    {
        ICRUD<RespuestaUsuario> repository;
        IUnitOfWork unitOfWork;

        public RespuestaUsuarioService(ICRUD<RespuestaUsuario> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public RespuestaUsuarioService() : this(new RespuestaUsuarioRepository(), new UnitOfWork())
        {

        }

        public List<RespuestaUsuario> ListarTodo()
        {
            try
            {
                return repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Guardar(RespuestaUsuario respuesta)
        {
            try
            {
                repository.Create(respuesta);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Guardar(List<RespuestaUsuario> respuestas)
        {
            try
            {
                foreach (var item in respuestas)
                {
                    //item.IdUsuario = HttpContext.Current.User.Identity.GetUserId();
                    repository.Create(item);
                }
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public RespuestaUsuario ObtenerPorId(int id)
        {
            try
            {
                RespuestaUsuario r = repository.GetByID(id);
                if (r != null)
                    return r;

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                repository.Delete(id);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar(RespuestaUsuario respuesta)
        {
            try
            {
                repository.Update(respuesta);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}