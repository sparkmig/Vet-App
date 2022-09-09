using System.Linq.Expressions;

namespace Vet.Business.Owner
{
    public interface IOwnerService
    {
        IQueryable<Models.Owner> GetOwners(Expression<Func<Models.Owner, bool>> predicate = null);
    }
}