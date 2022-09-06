using System.ComponentModel.DataAnnotations.Schema;

namespace Vet.Models
{
    [Table("OrderLines")]
    public class OrderLine
    {
        public int Id { get; set; }

        public int TreatmentId { get; set; }

        public int Amount { get; set; }

        public Treatment MyProperty { get; set; }

        public double Price { get; set; }

        public int VetId { get; set; }
    }
}