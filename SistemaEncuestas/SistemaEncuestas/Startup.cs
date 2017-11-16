using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SistemaEncuestas.Models;

[assembly: OwinStartupAttribute(typeof(SistemaEncuestas.Startup))]
namespace SistemaEncuestas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        //Metodo para crear rol de admin y usuario
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser();

            //Comprobaacion rol Admin
            if (!roleManager.RoleExists("Admin"))
            {
                var rol = new IdentityRole();

                rol.Name = "Admin";
                roleManager.Create(rol);

                user.Nombre = "Ciro";
                user.Email = "ciro@ejemplo.com";
                user.UserName = user.Email;
                user.Apellidos = "Mendoza Eumaña";
                user.Sexo = "Hombre";

                string userPWD = "123456";

                var chkUser = userManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRoles(user.Id, "Admin");
                }

            }

            if(!roleManager.RoleExists("User"))
            {
                var rol = new IdentityRole();

                rol.Name = "User";
                roleManager.Create(rol);

            }
   
        }
    }

}
