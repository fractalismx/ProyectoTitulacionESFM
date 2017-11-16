using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaEncuestas.Models.Repository.Infrastructure
{
    public class UsuarioContext
    {
        static ApplicationDbContext encuestaContext = null;

        internal static ApplicationDbContext GetContextUser()
        {
            return encuestaContext = encuestaContext ?? new ApplicationDbContext();
        }
    }
}