using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionProyectosAPI.Data;
using GestionProyectosAPI.DTOs;
using GestionProyectosAPI.Models;
using GestionProyectosAPI.DTOs.GestionProyectosAPI.DTOs;

namespace GestionProyectosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProyectosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProyectoReadDto>>> GetProyectos()
        {
            var proyectos = await _context.Proyectos
                .Include(p => p.Equipo)
                .Include(p => p.Tareas)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ProyectoReadDto>>(proyectos));
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProyectoReadDto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyectos
                .Include(p => p.Equipo)
                .Include(p => p.Tareas)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProyectoReadDto>(proyecto));
        }

        // POST: api/Proyectos
        [HttpPost]
        public async Task<ActionResult<ProyectoReadDto>> PostProyecto(ProyectoCreateDto proyectoCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar que el Equipo asociado existe
            var equipo = await _context.Equipos.FindAsync(proyectoCreateDto.EquipoId);
            if (equipo == null)
            {
                return BadRequest("El equipo asociado no existe.");
            }

            var proyecto = _mapper.Map<Proyecto>(proyectoCreateDto);

            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();

            var proyectoReadDto = _mapper.Map<ProyectoReadDto>(proyecto);

            return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyectoReadDto);
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, ProyectoCreateDto proyectoUpdateDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            // Verificar que el Equipo asociado existe
            var equipo = await _context.Equipos.FindAsync(proyectoUpdateDto.EquipoId);
            if (equipo == null)
            {
                return BadRequest("El equipo asociado no existe.");
            }

            _mapper.Map(proyectoUpdateDto, proyecto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.Id == id);
        }
    }
}
