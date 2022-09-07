using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vet.Business.Pet;
using Vet.Business.Treatment;
using Vet.Models;

namespace MauiVetApp.Models
{
    internal class CreateOrderPageModel : IQueryAttributable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PetDTO Pet { get; set; }

        private PetService PetService { get; }

        private TreatmentService TreatmentService { get; set; }

        public ObservableCollection<Owner> Owners { get; set; }
        
        public ObservableCollection<Treatment> Treatments { get; set; }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int petId = int.Parse(query["petId"].ToString());
            Pet = await PetService.GetPetDTO(petId);
            foreach (var owner in Pet.Owners)
                Owners.Add(owner);

            OnPropertyChanged(nameof(Pet));
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CreateOrderPageModel()
        {
            PetService = new PetService();
            TreatmentService = new TreatmentService();

            Owners = new();
            Treatments = new ObservableCollection<Treatment>(TreatmentService.GetTreatments());
        }
    }
}
