using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlkemyTomas.Models;
using Microsoft.Extensions.Configuration;
using AlkemyTomas.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace AlkemyTomas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PeliculasController : ControllerBase
    {

        private readonly Context _context;
       
       
        public PeliculasController(Context context)
        {
            _context = context;
            
        }

        // GET: api/Peliculas
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Peliculas>>> GetPelicula()
        {
            return await _context.Pelicula.ToListAsync();
        }
       
        [HttpGet]
        [Route("Peliculas/{title}")]
        public List<Peliculas> Search(string title)
        {

            var store = _context.Pelicula.Where(a => a.Title.Contains(title)).ToList();
            return store;
        }
        [HttpGet]
        [Route("/moviesorder=ASC")]
        public ActionResult<IEnumerable<Peliculas>> OrderBy()
        {
            try
            {

                var orderByDescendingResult = (from s in _context.Pelicula
                                               orderby s.date descending
                                               select s).ToListAsync();
                return Ok(orderByDescendingResult);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message + "ERROR");
            } 
        }
                
            [HttpGet]
            [Route("/detallepelicula")]
        public ActionResult<IEnumerable<Personajes>> DetallePeliculas()
        {


            try
            {
                var i = _context.Genero.GroupJoin(_context.Pelicula, std => std.GenderId,
            s => s.GenderId, (std, PeliculaconGenero) => new
            {
                Pelicula = PeliculaconGenero,
                GenderId = std.GenderId


            });

                foreach (var item in i)
                {
                    Console.WriteLine(item.GenderId);

                    foreach (var stud in item.Pelicula)
                        Console.WriteLine(stud.Title);
                }
                return Ok(i); }
            catch
            {
                return BadRequest("Error");
            }



        }


        // GET: api/Peliculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peliculas>> GetPeliculas(long id)
        {
            var peliculas = await _context.Pelicula.FindAsync(id);

            if (peliculas == null)
            {
                return NotFound();
            }

            return peliculas;
        }

        // PUT: api/Peliculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeliculas(long id, Peliculas peliculas)
        {
            if (id != peliculas.Id)
            {
                return BadRequest();
            }

            _context.Entry(peliculas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculasExists(id))
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

        // POST: api/Peliculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Peliculas>> PostPeliculas(Peliculas peliculas)
        {
           
            _context.Pelicula.Add(peliculas);
             await _context.SaveChangesAsync();

            
            return CreatedAtAction("GetPeliculas", new { id = peliculas.Id }, peliculas);
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeliculas(long id)
        {
            var peliculas = await _context.Pelicula.FindAsync(id);
            if (peliculas == null)
            {
                return NotFound();
            }

            _context.Pelicula.Remove(peliculas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeliculasExists(long id)
        {
            return _context.Pelicula.Any(e => e.Id == id);
        }
    }
}
