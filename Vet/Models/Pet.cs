using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Models
{
    [Table("Pets")]
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AnimalTypeId { get; set; }

        public DateTime Birthdate { get; set; }

        [ForeignKey("AnimalTypeId")]
        public AnimalType AnimalType { get; set; }
    }
}
