using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data.Entities
{
    public class History
    {
        public int Id { get; set; }


        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Description { get; set; }


        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateLocal => Date.ToLocalTime();


        public string Remarks { get; set; }



        //Una historia tiene un tipo de servicio
        //Un tipo de servicio tiene muchas historias
        public ServiceType ServiceType { get; set; }


        //Una historia tiene una mascota
        //Una mascota tiene muchas historias
        public Pet Pet { get; set; }

    }
}
