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
    public class PetService
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
            var pet = await GetPet(id);

            PetDTO dto = new PetDTO();
            dto.Id = pet.Id;
            dto.Name = pet.Name;
            dto.AnimalType = pet.AnimalType?.Name;

            return dto;
        }

        public PetService()
        {
            VetContext = new VetContext();
        }
    }
}
