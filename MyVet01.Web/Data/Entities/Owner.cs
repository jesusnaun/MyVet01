using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(15, ErrorMessage = "El {0} no puede tener más de {1} de caracteres.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} de caracteres.")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} de caracteres.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Teléfono Fijo")]
        public int FixedPhone { get; set; }

        [MaxLength(20)]
        [Display(Name = "Celular")]
        public int CellPhone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Dirección")]
        public int Address { get; set; }


        //public string FullName
        //{
        //    get
        //    {
        //        return $"{FirstName}{LastName}";
        //    }
        //}
        [Display(Name = "Dueño")]
        public string FullName => $"{FirstName}{LastName}";

        [Display(Name = "Dueño")]
        public string FullNameWithDocument => $"{FirstName}{LastName} - {Document}";


        // Un dueño tiene muchas mascotas
        // una mascota tiene un dueño
        public ICollection<Pet> Pets { get; set; }


        // Un dueño tiene muchas agendas
        // una agenda tiene un dueño
        public ICollection<Agenda> Agendas { get; set; }
    }
}
