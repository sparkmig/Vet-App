using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vet.Contexts;

namespace Vet.Business.Order
{
    public class OrderService
    {
        private VetContext VetContext { get; set; }

        public IQueryable<Models.Order> GetOrders(Expression<Func<Models.Order, bool>> predicate = null)
        {
            if (predicate == null)
                return VetContext.Orders;
            return VetContext.Orders.Where(predicate);
        }

        public OrderService()
        {
            VetContext = new VetContext();
        }
    }
}
