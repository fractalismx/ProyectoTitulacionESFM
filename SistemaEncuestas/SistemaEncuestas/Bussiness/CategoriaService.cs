using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository;
using SistemaEncuestas.Models.Repository.Entity;
using SistemaEncuestas.Models.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEncuestas.Bussiness
{
    public class CategoriaService
    {
        ICRUD<Categoria> repository;
        IUnitOfWork unitOfWork;

        public CategoriaService(ICRUD<Categoria> repository,IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public CategoriaService(): this(new CategoriaRepository(),new UnitOfWork())
        {

        }

        public List<Categoria> ListarTodo()
        {
            try
            {
                return repository.GetAll().ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool Guardar(Categoria categoria)
        {
            try
            {
                repository.Create(categoria);
                unitOfWork.Commit();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Categoria ObtenerPorId(int id)
        {
            try
            {
                Categoria c = repository.GetByID(id);
                if (c != null)
                    return c;

                return null;
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar(Categoria categoria)
        {
            try
            {
                repository.Update(categoria);
                unitOfWork.Commit();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}