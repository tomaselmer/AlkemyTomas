using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AlkemyTomas.Models
{
    public class Context : IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context> options)
               : base(options)
        {
        }

        public DbSet<Personajes> Persona { get; set; }
        public DbSet<Peliculas> Pelicula { get; set; }
        public DbSet<Generos> Genero { get; set; }
        public DbSet<UserInfo> MyUsers { get; set; }
    }
}

