using System.ComponentModel.DataAnnotations.Schema;

namespace Vet.Models
{
    [Table("Treatments")]
    public class Treatment
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }
    }
}