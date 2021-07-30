using AlkemyTomas.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyTomas.Models
{
    public class UserInfo
    {

        public string Email { get; set; }
      [Key]  
        public string Password { get; set; }
    }
}