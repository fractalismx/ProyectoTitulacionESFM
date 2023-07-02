using SistemaEncuestas.Models.Domain;
using SistemaEncuestas.Models.Repository;
using SistemaEncuestas.Models.Repository.Entity;
using SistemaEncuestas.Models.Repository.Infrastructure;
using SistemaEncuestas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Bussiness
{
    public class EncuestaService
    {
        ICRUD<Encuesta> repository;
        ICRUD<Pregunta> repositoryPreg;
        ICRUD<Respuesta> repositoryRespuesta;
        IUnitOfWork unitOfWork;

        public EncuestaService(ICRUD<Encuesta> repository, IUnitOfWork unitOfWork, ICRUD<Pregunta> repositoryPreg, ICRUD<Respuesta> repositoryRespuesta)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.repositoryPreg = repositoryPreg;
            this.repositoryRespuesta = repositoryRespuesta;
        }

        public EncuestaService() : this(new EncuestaRepository(), new UnitOfWork(), new PreguntaRepository(), new RespuestaRepository())
        {

        }

        public List<Encuesta> ListarTodo()
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

        public EncuestaViewModel CargarPreguntas(int id)
        {
            EncuestaViewModel listaP = new EncuestaViewModel();

            try
            {
                listaP.Preguntas = repositoryPreg.GetAll().Where(c => c.IdEncuestas == id).Select(c => c).ToList();
                listaP.Respuestas = new List<List<Respuesta>>();

                if (listaP.Preguntas.Count > 0)
                {
                    foreach (Pregunta pregunta in listaP.Preguntas)
                    {
                        int idPregunta = pregunta.Id;
                        List<Respuesta> respuestas = CargarRespuestaPregunta(idPregunta);

                        if (respuestas.Count > 0)
                            listaP.Respuestas.Add(respuestas);
                    }
                }

                return listaP;
            }
            catch (Exception ex)
            {
                return listaP;
            }
        }

        public List<Respuesta> CargarRespuestaPregunta(int idPregunta)
        {
            List<Respuesta> listaRespuesta = new List<Respuesta>();

            try
            {
                listaRespuesta = repositoryRespuesta.GetAll().Where(c => c.IdPreguntas == idPregunta).Select(c => c).ToList();
      
                return listaRespuesta;
            }
            catch (Exception ex)
            {
                return listaRespuesta;
            }
        }

        public bool Guardar(Encuesta encuesta)
        {
            try
            {
                repository.Create(encuesta);
                unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Encuesta ObtenerPorId(int id)
        {
            try
            {
                Encuesta e = repository.GetByID(id);
                if (e != null)
                    return e;

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

        public bool Actualizar(Encuesta encuesta)
        {
            try
            {
                repository.Update(encuesta);
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