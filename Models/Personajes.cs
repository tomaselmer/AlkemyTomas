using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTomas.Models
{
    public class Personajes
    {
        public Personajes()
        {

        }
        public Personajes(string story, long id, string name, int age, string movies, float weight, string image, long movieid)
        {
            Id = id;
            Name = name;
            Age = age;
            Movies = movies;
            Weight = weight;
            Image = image;
            MovieId = movieid;
            Story = Story;
        }
        [Key]
        public long Id { get; set; }
        [ForeignKey("Movie")]
        public long MovieId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Movies { get; set; }
        public float Weight { get; set; }
        public string Image { get; set; } //deberia ser byte[]
        public string Story { get; set; }
    }
}
