using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet01.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        //CREAR EL CAMPO
        private readonly DataContext _dataContext;
        //CONSTRUCTOR PARA APLICAR INYECCIONES
        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            //var list = new List<SelectListItem>();
            //foreach (var petType in _dataContext.PetTypes)
            //{
            //    list.Add(new SelectListItem
            //    {
            //        Text = petType.Name,
            //        Value = $"{petType.Id}"
            //    });
            //}

            var list = _dataContext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione Tipo de Mascota...]",
                Value = "0"
            });
            return list;

        }

    }
}
