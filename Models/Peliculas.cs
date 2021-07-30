using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTomas.Models
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme   )]
    public class Peliculas
    {
        public Peliculas()
        {
        }
        public Peliculas(long genderid, string image, string title, double date, int calification, long id)
        {
            GenderId = genderid;
            Image = image;
            Title = title;
            this.date = date;
            Calification = calification;
            Id = id;
            
        }
        [Key]
        public long Id { get; set; }
        public List<Personajes> MovieCharacter { get; }
        [ForeignKey("Gender")]
        public long GenderId { get; set; }
        public string Image { get; set; } //deberia ser byte[]
        public string Title { get; set; }
        public double date { get; set; } //cambiar a DateTime
        public int Calification { get; set; }
        
    }
}