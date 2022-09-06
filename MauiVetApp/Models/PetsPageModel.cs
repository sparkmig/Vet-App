using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Business.Pet;
using Vet.Models;

namespace MauiVetApp.Models
{
    internal class PetsPageModel
    {
        public IEnumerable<Pet> Pets { get; set; }

        public PetsPageModel()
        {
            Pets = new PetService().GetPets();
        }
    }
}
