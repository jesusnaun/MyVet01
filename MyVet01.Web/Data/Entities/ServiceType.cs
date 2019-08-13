using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }


        [Display(Name = "Tipo de Servicio")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Name { get; set; }



        //Una historia tiene un tipo de servicio
        //Un tipo de servicio tiene muchas historias
        public ICollection<History> Histories { get; set; }
    }
}
