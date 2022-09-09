using System.Linq.Expressions;

namespace Vet.Business.Order
{
    public interface IOrderService
    {
        IQueryable<Models.Order> GetOrders(Expression<Func<Models.Order, bool>> predicate = null);
    }
}