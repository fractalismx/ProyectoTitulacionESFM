using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaEncuestas.Models;

namespace SistemaEncuestas.Models.Repository.Infrastructure
{
    public class ContextFactory
    {
        static ApplicationDbContext encuestaContext = null;

        internal static ApplicationDbContext GetContext()
        {
            return encuestaContext = encuestaContext ?? new ApplicationDbContext();
        }
    }
}