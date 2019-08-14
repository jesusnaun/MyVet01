using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Models
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress]  //VALIDA QUE EL FORMATO CORREO SEA VÁLIDO
        public string Username { get; set; }


        [Required]
        [MinLength(6)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }


    }
}
