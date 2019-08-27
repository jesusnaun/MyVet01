using System.Threading.Tasks;
using MyVet01.Web.Data.Entities;
using MyVet01.Web.Models;

namespace MyVet01.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path);
    }
}