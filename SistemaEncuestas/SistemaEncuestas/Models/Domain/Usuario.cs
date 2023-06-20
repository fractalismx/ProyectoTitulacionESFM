using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaEncuestas.Models.Domain
{
    [Table("AspNetUsers")]
    public class Usuario
    {
        private string id;
        private string nombre;
        private string apellidos;
        private int genero;
        private string email;

        public Usuario()
        {
            ActionsList = new List<SelectListItem>();
        }

        [NotMapped]
        public IEnumerable<SelectListItem> ActionsList 
        { 
            get; 
            set; 
        }

        [Key]
        [Column("Id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("Nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Column("Apellidos")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        [Column("Genero")]
        public int Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        [Column("Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}