using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vet.Business.Treatment;
using Vet.Models;

namespace MauiVetApp.Models
{
    internal class StatisticOverviewPageModel: INotifyPropertyChanged
    {
        private TreatmentService TreatmentService { get; }
        
        public TreatmentStatistic TreatmentStatistic { get; set; }

        public IEnumerable<Treatment> Treatments { get; set; }

        public Treatment SelectedTreatment { get; set; }

        public StatisticOverviewPageModel()
        {
            TreatmentService = new TreatmentService();
            Treatments = TreatmentService.GetTreatments().ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void SelectedChanged()
        {
            TreatmentStatistic = TreatmentService.GetTreatmentStatistic(SelectedTreatment.Id);
            OnPropertyChanged(nameof(TreatmentStatistic));
        }
    }
}
