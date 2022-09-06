using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Models;

namespace Vet.Contexts
{
    internal class VetContext: DbContext
    {
        public DbSet<Owner> Owners { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-AHVBG46;Database=Vet;User Id=VetDb;Password=VetDb123;encrypt=true;trustServerCertificate=true");
        }
    }
}
