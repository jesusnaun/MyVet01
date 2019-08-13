using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyVet01.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet01.Web.Data
{
    //public class DataContext : DbContext
    //Al usar identitiy dejamos de usar el DataContext
        public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }


    }
}
