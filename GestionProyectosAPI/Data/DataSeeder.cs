using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GestionProyectosAPI.Data // Asegúrate de que el namespace coincida con el de tu proyecto
{
    public class DataSeeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Verificar si el rol Administrador ya existe, si no, crearlo
            if (!await roleManager.RoleExistsAsync("Administrador"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrador"));
            }

            // Verificar si el rol Usuario ya existe, si no, crearlo
            if (!await roleManager.RoleExistsAsync("Usuario"))
            {
                await roleManager.CreateAsync(new IdentityRole("Usuario"));
            }
        }
    }
}
