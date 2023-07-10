using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository;
using SistemaEncuestas.Models.Repository.Entity;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEncuestas.Bussiness
{
    public class RespuestaService
    {
        ICRUD<Respuesta> repository;
        IUnitOfWork unitOfWork;

        public RespuestaService(ICRUD<Respuesta> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public RespuestaService(): this(new RespuestaRepository(),new UnitOfWork())
        {

        }

        public List<Respuesta> ListarTodo()
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

        public bool Guardar(Respuesta respuesta)
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

        public bool Guardar(List<Respuesta> respuestas)
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

        public Respuesta ObtenerPorId(int id)
        {
            try
            {
                Respuesta r = repository.GetByID(id);
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

        public bool Actualizar(Respuesta respuesta)
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