using System.ComponentModel.DataAnnotations;

namespace AlkemyTomas.Models
{
    public class LoginView
    {
     
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z]).{6,12}$", ErrorMessage = "Contraseña NO valida!!!")]
        public string Password { get; set; }
    }
}