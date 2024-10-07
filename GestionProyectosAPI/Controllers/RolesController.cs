using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionProyectosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Crear un nuevo usuario y opcionalmente asignar un rol
        [HttpPost("crear-usuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioModel model)
        {
            // Verificar si el usuario ya existe
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest("El usuario ya existe.");

            // Crear el nuevo usuario
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Asignar el rol si está especificado
                if (!string.IsNullOrEmpty(model.Role))
                {
                    var roleExists = await _roleManager.RoleExistsAsync(model.Role);
                    if (roleExists)
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                    }
                    else
                    {
                        return BadRequest($"El rol '{model.Role}' no existe.");
                    }
                }
                return Ok("Usuario creado correctamente.");
            }

            return BadRequest("Error al crear el usuario.");
        }

        // Modificar los datos de un usuario
        [HttpPut("modificar-usuario/{email}")]
        public async Task<IActionResult> ModificarUsuario(string email, [FromBody] ModificarUsuarioModel model)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound("Usuario no encontrado.");

            // Modificar email y username
            user.Email = model.NewEmail ?? user.Email;
            user.UserName = model.NewEmail ?? user.UserName;

            // Guardar los cambios en el usuario
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok("Usuario modificado correctamente.");

            return BadRequest("Error al modificar el usuario.");
        }

        // Asignar un rol a un usuario existente
        [HttpPost("asignar-rol")]
        public async Task<IActionResult> AsignarRol([FromBody] AsignarRolModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var roleExists = await _roleManager.RoleExistsAsync(model.Role);
            if (!roleExists)
            {
                return BadRequest("El rol especificado no existe.");
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok("Rol asignado correctamente.");
            }

            return BadRequest("No se pudo asignar el rol.");
        }

        // Eliminar un rol de un usuario
        [HttpPost("remover-rol")]
        public async Task<IActionResult> RemoverRol([FromBody] AsignarRolModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok("Rol removido correctamente.");
            }

            return BadRequest("No se pudo remover el rol.");
        }
    }

    // Modelos de datos para las solicitudes
    public class CrearUsuarioModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class ModificarUsuarioModel
    {
        public string NewEmail { get; set; }
    }

    public class AsignarRolModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
