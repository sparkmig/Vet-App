using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet.Models
{
    public class TreatmentStatistic
    {
        public Treatment Treatment { get; set; }

        public int Amount { get; set; }
        
        public DateTime LastTreatmentDate { get; set; }

        public double TotalSum { get; set; }
    }
}
