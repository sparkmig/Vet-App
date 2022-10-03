using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Vet.Business.Pet;
using Vet.Models;
using Website.Data;

namespace Website.Controllers
{
    [Authorize]
    public class PetController: Controller
    {
        private readonly IPetService _petService;

        private readonly UserManager<IdentityUser> _userManager;

        public PetController(IPetService petService, UserManager<IdentityUser> userManager)
        {
            _petService = petService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Pets")]
        public async Task<IActionResult> Pets()
        {
            string userId = _userManager.GetUserId(User);
            var pets = await _petService.GetPets(pet => pet.PetOwners.Any(owner => owner.Owner.UserId == userId))
                                        .Include(x => x.AnimalType)
                                        .ToListAsync();

            return View(pets);
        }

        [HttpGet]
        [Route("Pet/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            string userId = _userManager.GetUserId(User);
            var pet = await _petService.GetPetDTO(id);

            if (pet?.Owners?.Any(owner => owner.UserId == userId) ?? false)
                return View(pet);
            else
                return NotFound();
        }
    }
}
