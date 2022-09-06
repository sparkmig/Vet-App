using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        
        public int PetId { get; set; }
        
        public int OwnerId { get; set; }
        
        public int OrderStatusId { get; set; }
        
        public DateTime Date { get; set; }

        [ForeignKey("OrderId")]
        public List<OrderLine> OrderLines { get; set; }
    }
}
