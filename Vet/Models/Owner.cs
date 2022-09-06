using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Models
{
    public class Owner
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string  LastName { get; set; }
        
        public string City { get; set; }
        
        public string StreetName { get; set; }
        
        public int StreetNumber { get; set; }
        
        public string Additional { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string PostalCode { get; set; }
    }
}
