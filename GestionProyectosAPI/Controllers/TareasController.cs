// GestionProyectosAPI/Controllers/TareasController.cs
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionProyectosAPI.Data;
using GestionProyectosAPI.DTOs;
using GestionProyectosAPI.Models;
using EstadoTarea = GestionProyectosAPI.DTOs.EstadoTarea;

namespace GestionProyectosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TareasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaReadDto>>> GetTareas()
        {
            var tareas = await _context.Tareas
                .Include(t => t.Proyecto)
                    .ThenInclude(p => p.Equipo)
                .ToListAsync();

            var tareasReadDto = _mapper.Map<IEnumerable<TareaReadDto>>(tareas);
            return Ok(tareasReadDto);
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TareaReadDto>> GetTarea(int id)
        {
            var tarea = await _context.Tareas
                .Include(t => t.Proyecto)
                    .ThenInclude(p => p.Equipo)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            var tareaReadDto = _mapper.Map<TareaReadDto>(tarea);
            return Ok(tareaReadDto);
        }

        // POST: api/Tareas
        [HttpPost]
        public async Task<ActionResult<TareaReadDto>> PostTarea(TareaCreateDto tareaCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validar que el valor de Estado es válido
            if (!Enum.IsDefined(typeof(EstadoTarea), tareaCreateDto.Estado))
            {
                return BadRequest("El estado proporcionado no es válido. Use 0 para Pendiente, 1 para EnProgreso o 2 para Completada.");
            }

            // Verificar que el Proyecto asociado existe
            var proyecto = await _context.Proyectos.FindAsync(tareaCreateDto.ProyectoId);
            if (proyecto == null)
            {
                return BadRequest("El proyecto asociado no existe.");
            }

            var tarea = _mapper.Map<Tarea>(tareaCreateDto);

            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            var tareaReadDto = _mapper.Map<TareaReadDto>(tarea);

            return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tareaReadDto);
        }

        // PUT: api/Tareas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, TareaCreateDto tareaUpdateDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            // Validar que el valor de Estado es válido
            if (!Enum.IsDefined(typeof(EstadoTarea), tareaUpdateDto.Estado))
            {
                return BadRequest("El estado proporcionado no es válido. Use 0 para Pendiente, 1 para EnProgreso o 2 para Completada.");
            }

            // Verificar que el Proyecto asociado existe
            var proyecto = await _context.Proyectos.FindAsync(tareaUpdateDto.ProyectoId);
            if (proyecto == null)
            {
                return BadRequest("El proyecto asociado no existe.");
            }

            _mapper.Map(tareaUpdateDto, tarea);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(id))
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

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.Id == id);
        }
    }
}
