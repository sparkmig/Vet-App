using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Vet.Business.Pet;
using Vet.Models;

namespace MauiVetApp.Models
{
    internal class PetDetailsPageModel: IQueryAttributable, INotifyPropertyChanged
    {
        public PetDTO Pet { get; set; }

        private PetService PetService { get; }

        public PetDetailsPageModel()
        {
            PetService = new PetService();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int petId = int.Parse(HttpUtility.UrlDecode(query["petId"].ToString()));

            Pet = await PetService.GetPetDTO(petId);

            OnPropertyChanged(nameof(Pet));

        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
