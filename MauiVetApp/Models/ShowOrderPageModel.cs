using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vet.Business.Order;
using Vet.Business.Pet;
using Vet.Models;

namespace MauiVetApp.Models
{
    internal class ShowOrderPageModel: IQueryAttributable, INotifyPropertyChanged
    {
        public ObservableCollection<Order> Orders { get; set; }

        private OrderService OrderService { get; }
        
        private PetService PetService { get; }

        public Order SelectedOrder { get; set; }

        public ShowOrderPageModel()
        {
            OrderService = new OrderService();
            PetService = new PetService();

            Orders = new();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int petId = int.Parse(query["petId"].ToString());
            var orders = OrderService.GetOrders(x => x.PetId == petId)
                .Include(x => x.OrderLines)
                .ThenInclude(x => x.Treatment)
                .Include(x => x.Owner);
            
            foreach (var order in orders)
                Orders.Add(order);

        }
    }
}
