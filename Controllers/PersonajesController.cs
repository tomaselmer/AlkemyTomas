using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlkemyTomas.Models;
using System.Net;

namespace AlkemyTomas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly Context _context;

        public PersonajesController(Context context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personajes>>> GetPersona()
        {
            return await _context.Persona.ToListAsync();
        }
        // GET: api/characters
        [HttpGet]
        [Route("Character")]
        public async Task<ActionResult<IEnumerable<PersonajesDTO>>> GetCharacter()
        {
            var items = _context.Persona
                 .Select(f => new PersonajesDTO
                 {
                     Name = f.Name,
                     Image = f.Image
                 })
                 .ToListAsync();
            return await items;
            
        }

        
         [HttpGet]
          [Route("search/charactersname")]
         public List<Personajes> Search(string name)
         {

            var store = _context.Persona.Where(a => a.Name.Contains(name)).ToList();
             return store;
         }


       [HttpGet]
        [Route("filter/age")]
        public async Task<ActionResult<IEnumerable<Personajes>>> Filter(int i, int j)
        {
          var Age = from s in _context.Persona
                                 where s.Age >= i && s.Age <= j
                                 select s;
           
            return await Age.ToListAsync();
        }
        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personajes>> GetPersonas(long id)
        {
            var personas = await _context.Persona.FindAsync(id);

            if (personas == null)
            {
                return NotFound();
            }

            return personas;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonas(long id, Personajes personas)
        {
            if (id != personas.Id)
            {
                return BadRequest();
            }

            _context.Entry(personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personajes>> PostPersonas(Personajes personas)
        {
            _context.Persona.Add(personas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonas", new { id = personas.Id }, personas);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonas(long id)
        {
            var personas = await _context.Persona.FindAsync(id);
            if (personas == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(personas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonasExists(long id)
        {
            return _context.Persona.Any(e => e.Id == id);
        }
    }
}
