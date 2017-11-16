using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Domain
{
    [Table("AspNetUsers")]
    public class Usuario
    {
        private string id;
        private string nombre;
        private string apellidos;
        private string sexo;
        private string email;

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

        [Column("Sexo")]
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        [Column("Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}