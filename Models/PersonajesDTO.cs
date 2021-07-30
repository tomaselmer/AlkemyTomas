using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTomas.Models
{
    public class PersonajesDTO
    {
        public PersonajesDTO()
        {
        }
        public PersonajesDTO(string image, string name)
        {
            Image = image;
            Name = name;
        }

        public string Image { get; set; } //deberia ser byte[]
        public string Name { get; set; }
    }
}
 