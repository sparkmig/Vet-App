using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Models
{
    public class PetDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string AnimalType { get; set; }

        public DateTime Birthdate { get; set; }

        public IEnumerable<Owner> Owners { get; set; }
        
        public IEnumerable<Order> Orders { get; set; }
    }
}
