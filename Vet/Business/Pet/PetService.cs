using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vet.Contexts;
using Vet.Models;

namespace Vet.Business.Pet
{
    public class PetService : IPetService
    {
        private VetContext VetContext { get; }

        public IQueryable<Models.Pet> GetPets(Expression<Func<Models.Pet, bool>> predicate = null)
        {
            if (predicate == null)
                return VetContext.Pets;

            return VetContext.Pets.Where(predicate);
        }

        public async Task<Models.Pet> GetPet(int id)
        {
            return await VetContext.Pets.Include(x => x.AnimalType).FirstAsync(pet => pet.Id == id);
        }

        public async Task<PetDTO> GetPetDTO(int id)
        {
            var table = VetContext.Pets;

            var query = table.Select(pet => new PetDTO()
            {
                Id = pet.Id,
                Name = pet.Name,
                AnimalType = pet.AnimalType.Name,
                Birthdate = pet.Birthdate,
                Owners = pet.PetOwners.Select(petOwner => petOwner.Owner).ToList()
            });

            PetDTO dto = await query.FirstOrDefaultAsync(pet => pet.Id == id);

            return dto;
        }

        public async Task NewInvoice(Models.Order order)
        {
            VetContext.Orders.Add(order);
            await VetContext.SaveChangesAsync();
        }
        public PetService()
        {
            VetContext = new VetContext();
        }
    }
}
