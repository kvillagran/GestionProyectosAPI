using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionProyectosAPI.Data;
using GestionProyectosAPI.DTOs;
using GestionProyectosAPI.Models;

namespace GestionProyectosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  // Requiere autenticación para acceder
    public class EquiposController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EquiposController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Equipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipoReadDto>>> GetEquipos()
        {
            var equipos = await _context.Equipos
                .Include(e => e.Proyectos)
                .ToListAsync();

            var equiposReadDto = _mapper.Map<IEnumerable<EquipoReadDto>>(equipos);
            return Ok(equiposReadDto);
        }

        // GET: api/Equipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipoReadDto>> GetEquipo(int id)
        {
            var equipo = await _context.Equipos
                .Include(e => e.Proyectos)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipo == null)
            {
                return NotFound();
            }

            var equipoReadDto = _mapper.Map<EquipoReadDto>(equipo);
            return Ok(equipoReadDto);
        }

        // POST: api/Equipos
        [HttpPost]
        [Authorize(Roles = "Administrador")]  // Solo los administradores pueden crear
        public async Task<ActionResult<EquipoReadDto>> PostEquipo(EquipoCreateDto equipoCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipo = _mapper.Map<Equipo>(equipoCreateDto);

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();

            var equipoReadDto = _mapper.Map<EquipoReadDto>(equipo);

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, equipoReadDto);
        }

        // PUT: api/Equipos/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]  // Solo los administradores pueden modificar
        public async Task<IActionResult> PutEquipo(int id, EquipoCreateDto equipoUpdateDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _mapper.Map(equipoUpdateDto, equipo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Equipos/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]  // Solo los administradores pueden eliminar
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }
    }
}
