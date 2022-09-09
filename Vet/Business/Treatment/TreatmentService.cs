using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vet.Contexts;
using Vet.Models;

namespace Vet.Business.Treatment
{
    public class TreatmentService : ITreatmentService
    {
        private VetContext VetContext { get; }

        public IQueryable<Models.Treatment> GetTreatments(Expression<Func<Models.Treatment, bool>> predicate = null)
        {
            if (predicate == null)
                return VetContext.Treatments;
            return VetContext.Treatments.Where(predicate);
        }

        public Models.Treatment GetTreatment(Expression<Func<Models.Treatment, bool>> predicate = null)
        {
            if (predicate == null)
                return VetContext.Treatments.FirstOrDefault();
            return VetContext.Treatments.FirstOrDefault(predicate);
        }

        public TreatmentStatistic GetTreatmentStatistic(int id, DateTime? from = null, DateTime? to = null)
        {

            var orders = VetContext.Orders;
            if (from != null)
                orders.Where(o => o.Date >= from);
            if (to != null)
                orders.Where(o => o.Date <= to);

            var orderLines = orders.SelectMany(o => o.OrderLines.Where(ol => ol.TreatmentId == id));
            DateTime lastTreatmentDate = orders
                .Where(x => x.OrderLines.Any(ol => ol.TreatmentId == id))
                .OrderByDescending(x => x.Date)
                .FirstOrDefault()
                .Date;

            TreatmentStatistic treatmentStatistic = new TreatmentStatistic()
            {
                Amount = orderLines.Count(),
                LastTreatmentDate = lastTreatmentDate,
                TotalSum = orderLines.Sum(ol => ol.Amount * ol.ProductPrice),
                Treatment = VetContext.Treatments.Find(id)
            };

            return treatmentStatistic;
        }

        public TreatmentService()
        {
            VetContext = new VetContext();
        }
    }
}
