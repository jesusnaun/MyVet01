using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data.Entities
{
    public class User : IdentityUser
    {


        [Display(Name = "Documento")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(15, ErrorMessage = "El {0} no puede tener más de {1} de caracteres.")]
        public string Document { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El {0} no puede tener más de {1} de caracteres.")]
        public string FirstName { get; set; }


        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El {0} no puede tener más de {1} de caracteres.")]
        public string LastName { get; set; }


        [MaxLength(100)]
        [Display(Name = "Dirección")]
        public int Address { get; set; }



        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName}{LastName}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName}{LastName} - {Document}";


    }
}
