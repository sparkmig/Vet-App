using System.Linq.Expressions;
using Vet.Models;

namespace Vet.Business.Pet
{
    public interface IPetService
    {
        Task<Models.Pet> GetPet(int id);
        Task<PetDTO> GetPetDTO(int id);
        IQueryable<Models.Pet> GetPets(Expression<Func<Models.Pet, bool>> predicate = null);
        Task NewInvoice(Models.Order order);
    }
}