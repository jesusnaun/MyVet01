using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data.Entities
{
    public class Agenda
    {

        public int Id { get; set; }


        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}")]
        public DateTime DateLocal => Date.ToLocalTime();


        public string Remarks { get; set; }

        [Display(Name = "Está disponible?")]
        public bool IsAvailable { get; set; }



        // Una agenda tiene un dueño
        // una agenda tiene una mascota
        public Owner Owner { get; set; }
        public Pet Pet { get; set; }
    }
}
