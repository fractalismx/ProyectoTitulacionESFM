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
        IUnitOfWork unitOfWork;

        public EncuestaService(ICRUD<Encuesta> repository, IUnitOfWork unitOfWork,ICRUD<Pregunta> repositoryPreg)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.repositoryPreg = repositoryPreg;
        }

        public EncuestaService(): this(new EncuestaRepository(),new UnitOfWork(),new PreguntaRepository())
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

        public EncuestaViewModel Contestar(int id)
        {
            EncuestaViewModel listaP = new EncuestaViewModel();
            
            try
            {
                List<Pregunta> pregs = repositoryPreg.GetAll().Where(c => c.IdEncuestas == id).Select(c=>c).ToList();
                listaP = FactoryRespuesta(pregs);

                return listaP;
            }
            catch(Exception ex)
            {
                return listaP;
            }   
        }

        private EncuestaViewModel FactoryRespuesta(List<Pregunta> pregs)
        {
            EncuestaViewModel listaFinal = new EncuestaViewModel();
            listaFinal.Preguntas = pregs;
            listaFinal.Respuestas = new List<Respuesta>();

            for (int i = 0; i < pregs.Count; i++)
                listaFinal.Respuestas.Add(new Respuesta { IdPreguntas = pregs[i].Id });

            return listaFinal;
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