using Crud_Profesores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud_Profesores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly ProfesoresContext _context;

        public ProfesoresController(ProfesoresContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("crearProfesor")]
        public async Task<IActionResult> CreateProfesor(Profesores profesor)
        {
            // Guardar el profesor en la base de datos
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();

            // Devolver un mensaje de éxito
            return Ok();
        }

        [HttpGet]
        [Route("listaProfesores")]
        public async Task<ActionResult<IEnumerable<Profesores>>> GetProfesores()
        {
            // Obtener la lista de profesores de la base de datos
            var profesores = await _context.Profesores.ToListAsync();

            // Devolver una lista de profesores
            return Ok(profesores);
        }

        [HttpGet]
        [Route("verProfesor")]
        public async Task<IActionResult> GetProfesor(int id)
        {
            // Obtener el profesor de la base de datos
            Profesores profesor = await _context.Profesores.FindAsync(id);

            // Devolver el profesor
            if (profesor == null)
            {
                return NotFound();
            }

            return Ok(profesor);
        }

        [HttpPut]
        [Route("editarProfesor")]
        public async Task<IActionResult> UpdateProfesor(int id, Profesores profesor)
        {
            // Actualizar el profesor en la base de datos
            var profesorExistente = await _context.Profesores.FindAsync(id);
            profesorExistente.Name = profesor.Name;
            profesorExistente.Subject = profesor.Subject;
            profesorExistente.Grade = profesor.Grade;

            await _context.SaveChangesAsync();

            // Devolver un mensaje de éxito
            return Ok();
        }

        [HttpDelete]
        [Route("eliminarProfesor")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            // Eliminar profesor de la base de datos
            var profesorBorrado = await _context.Profesores.FindAsync(id);
            _context.Profesores.Remove(profesorBorrado);

            await _context.SaveChangesAsync();

            // Devolver un mensaje de éxito
            return Ok();
        }
    }
}
