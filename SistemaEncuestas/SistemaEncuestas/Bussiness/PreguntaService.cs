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
    public class PreguntaService
    {
        ICRUD<Pregunta> repository;
        IUnitOfWork unitOfWork;

        public PreguntaService(ICRUD<Pregunta> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public PreguntaService(): this(new PreguntaRepository(),new UnitOfWork())
        {

        }

        public List<Pregunta> ListarTodo()
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

        public bool Guardar(Pregunta pregunta)
        {
            try
            {
                repository.Create(pregunta);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Pregunta ObtenerPorId(int id)
        {
            try
            {
                Pregunta p = repository.GetByID(id);
                if (p != null)
                    return p;

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

        public bool Actualizar(Pregunta pregunta)
        {
            try
            {
                repository.Update(pregunta);
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