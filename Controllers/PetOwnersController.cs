using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }

         // GET /api/petowners
        // Returns all petowners
        // Note that `IEnumerable<Bread>` is C#'s fancy way 
        // of saying "a list of petowner objects"
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners()
        {
            return _context.PetOwners;
            // Include the `bakedBy` property
            // which is a list of `Baker` objects
            // .NET will do a JOIN for us!
            // .Include(petowner => petowner.bakedBy);
        }

        // POST /api/petowners
        // .NET automatically converts our JSON request body
        // into a `PetOwners` object. 
        [HttpPost]
        public PetOwner Post(PetOwner petOwner)
        {
            // Tell the DB context about our new bread object
            _context.Add(petOwner);
            // ...and save the bread object to the database
            _context.SaveChanges();

            // Respond back with the created bread object
            return petOwner;
        }







        //END of class
    }
}
