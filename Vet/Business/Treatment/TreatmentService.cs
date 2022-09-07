using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vet.Contexts;

namespace Vet.Business.Treatment
{
    public class TreatmentService
    {
        private VetContext VetContext { get; }

        public IQueryable<Models.Treatment> GetTreatments(Expression<Func<Models.Treatment, bool>> predicate = null)
        {
            if (predicate == null)
                return VetContext.Treatments;
            return VetContext.Treatments.Where(predicate);
        }

        public TreatmentService()
        {
            VetContext = new VetContext();
        }
    }
}
