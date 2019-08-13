using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data.Entities
{
    public class Pet
    {

        public int Id { get; set; }


        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Foto")]
        public string ImageUrl { get; set; }

        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        public string Race { get; set; }

        [Display(Name = "Nacimiento")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }


        [Display(Name = "Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BornLocal => Born.ToLocalTime();

        public string Remarks { get; set; }


        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"http:algo.com/imgenes{ImageUrl.Substring(1)}";




        // Un tipo de mascota tiene muchas mascotas
        // una mascota tiene un tipo de mascota
        public PetType PetType { get; set; }

        // Un dueño tiene muchas mascotas
        // una mascota tiene un dueño
        public Owner Owner { get; set; }


        //Una historia tiene una mascota
        //Una mascota tiene muchas historias
        public ICollection<History> Histories { get; set; }



        // Una mascota tiene muchas agendas
        // una agenda tiene una Mascota
        public ICollection<Agenda> Agendas { get; set; }

    }
}
