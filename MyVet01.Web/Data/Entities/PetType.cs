using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data.Entities
{
    public class PetType
    {
        public int Id { get; set; }


        [Display(Name = "Tipo de Mascota")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Name { get; set; }


        // Un tipo de mascota tiene muchas mascotas
        // una mascota tiene un tipo de mascota
        public ICollection<Pet> Pets { get; set; }

    }
}
