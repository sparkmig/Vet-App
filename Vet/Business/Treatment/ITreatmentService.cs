using System.Linq.Expressions;
using Vet.Models;

namespace Vet.Business.Treatment
{
    public interface ITreatmentService
    {
        Models.Treatment GetTreatment(Expression<Func<Models.Treatment, bool>> predicate = null);
        IQueryable<Models.Treatment> GetTreatments(Expression<Func<Models.Treatment, bool>> predicate = null);
        TreatmentStatistic GetTreatmentStatistic(int id, DateTime? from = null, DateTime? to = null);
    }
}