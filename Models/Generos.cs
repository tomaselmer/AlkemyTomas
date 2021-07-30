using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTomas.Models
{
    public class Generos
    {
        public Generos()
        {
        }
        public Generos(long genderid, string image, string title, double date, int calification, string characters, long id)
        {
            GenderId = genderid;
            Image = image;
            Title = title;
            this.date = date;
            Calification = calification;
            Characters = characters;
            Id = id;
        }
        [Key]
        public long Id { get; set; }
        [ForeignKey("Genero")]
        public long GenderId { get; set; }
        public string Image { get; set; } //deberia ser byte[]
        public string Title { get; set; }
        public double date { get; set; }
        public int Calification { get; set; }
        public string Characters { get; set; }
    }
}
