using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Models
{
    [Table("PetOwners")]
    public class PetOwner
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public int PetId { get; set; }

    }
}
