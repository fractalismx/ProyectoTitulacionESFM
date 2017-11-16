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
    public class UsuarioService
    {
        ICRUD<Usuario> repository;
        ICRUD<Respuesta> repositoryRespuesta;
        ICRUD<Pregunta> repositoryPregunta;
        ICRUD<Encuesta> repositoryEncuesta;

        IUnitOfWork unitOfWork;

        public UsuarioService(ICRUD<Usuario> repository,
                              ICRUD<Respuesta> repositoryRespuesta,
                              ICRUD<Pregunta> repositoryPregunta,
                              ICRUD<Encuesta> repositoryEncuesta,
                              IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.repositoryRespuesta = repositoryRespuesta;
            this.repositoryPregunta = repositoryPregunta;
            this.repositoryEncuesta = repositoryEncuesta;
            this.unitOfWork = unitOfWork;
        }

        public UsuarioService() : this(new UsuarioRepository(),
                                       new RespuestaRepository(),
                                       new PreguntaRepository(),
                                       new EncuestaRepository(),
                                       new UnitOfWork())
        {

        }

        public List<Usuario> ListarTodo()
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

        public List<Encuesta> ListarEncuestas(string id)
        {
            List<Encuesta> enc = new List<Encuesta>();


            enc = repositoryRespuesta.GetAll().Where(c=>c.IdUsuario==id).Select(c => c.Preguntas.Encuestas).Distinct().ToList();

            return enc;
            
        }

        public bool Guardar(Usuario usuario)
        {
            try
            {
                repository.Create(usuario);

                unitOfWork.Commit();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Usuario ObtenerPorId(int id)
        {
            try
            {
                Usuario u = repository.GetByID(id);

                if (u != null)
                    return u;

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

        public bool Actualizar(Usuario usuario)
        {
            try
            {
                repository.Update(usuario);

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
