using MyVet01.Web.Data;
using MyVet01.Web.Data.Entities;
using MyVet01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        //PARA PODER OBETNER EL OWNER DE LA BASE DE DATOS
        private readonly DataContext _dataContext;
        public ConverterHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        //private Pet ToPet(PetViewModel model, string path)
        public async Task<Pet> ToPetAsync(PetViewModel model, string path)
        //COGE UN OBJETO PETviEWMODEL Y DEVULEVE UN OBJEtO PET
        {
            return new Pet
            {
                Agendas = model.Agendas,
                Born = model.Born,
                Histories = model.Histories,
                //HAY QUE REVISAR ESTE TEMA DEL ID
                //Id = model.Id,
                ImageUrl = path,
                Name = model.Name,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                PetType = await _dataContext.PetTypes.FindAsync(model.PetTypeId),
                Race = model.Race,
                Remarks = model.Remarks
            };

         
        }

    }
}
