using Backend.API.Data;
using Backend.API.Models;
using Backend.API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorMateriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfesorMateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Asignar materia a profesor
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AsignarMateria([FromBody] ProfesorMateriaDTO dto)
        {
            var profesor = await _context.Profesores.FindAsync(dto.IdProfesor);
            var materia = await _context.Materias.FindAsync(dto.IdMateria);

            if (profesor == null || materia == null)
                return BadRequest("Profesor o materia inválidos.");

            bool yaAsignado = await _context.ProfesorMaterias
                .AnyAsync(pm => pm.IdProfesor == dto.IdProfesor && pm.IdMateria == dto.IdMateria);

            if (yaAsignado)
                return BadRequest("El profesor ya tiene asignada esta materia.");

            var asignacion = new ProfesorMateria
            {
                IdProfesor = dto.IdProfesor,
                IdMateria = dto.IdMateria
            };

            _context.ProfesorMaterias.Add(asignacion);
            await _context.SaveChangesAsync();

            return Ok($"Materia '{materia.Nombre}' asignada al profesor {profesor.Nombre} correctamente.");
        }

        // ✅ Listar materias asignadas a un profesor
        [HttpGet("profesor/{idProfesor}")]
        [Authorize(Roles = "Admin,Profesor")]
        public async Task<IActionResult> GetMateriasPorProfesor(int idProfesor)
        {
            var materias = await _context.ProfesorMaterias
                .Include(pm => pm.Materia)
                .Where(pm => pm.IdProfesor == idProfesor)
                .Select(pm => new
                {
                    pm.Materia.IdMateria,
                    pm.Materia.Nombre,
                    pm.Materia.Codigo
                })
                .ToListAsync();

            return Ok(materias);
        }

        // ✅ Eliminar asignación
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> QuitarMateria([FromBody] ProfesorMateriaDTO dto)
        {
            var asignacion = await _context.ProfesorMaterias
                .FirstOrDefaultAsync(pm => pm.IdProfesor == dto.IdProfesor && pm.IdMateria == dto.IdMateria);

            if (asignacion == null)
                return NotFound("La asignación no existe.");

            _context.ProfesorMaterias.Remove(asignacion);
            await _context.SaveChangesAsync();

            return Ok("Asignación eliminada correctamente.");
        }
    }
}
