using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vet.Contexts;
using Vet.Models;

namespace Vet.Business.Owner
{
    public class OwnerService : IOwnerService
    {
        private VetContext VetContext { get; set; }

        public IQueryable<Models.Owner> GetOwners(Expression<Func<Models.Owner, bool>> predicate = null)
        {
            if (predicate == null)
                return VetContext.Owners;

            return VetContext.Owners.Where(predicate);
        }

        public OwnerService()
        {
            VetContext = new VetContext();
        }
    }
}
