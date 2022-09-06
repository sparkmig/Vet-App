using MauiVetApp.Views;
using Vet.Business.Owner;
using Vet.Business.Pet;
using Vet.Models;

namespace MauiVetApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        Routing.RegisterRoute("pets/all", typeof(PetsPage ));
        Routing.RegisterRoute("pets/details", typeof(PetDetailsPage));
        Routing.RegisterRoute("pets/createOrder", typeof(CreateOrderPage));
        InitializeComponent();
    }

    private void ShowAnimals_Btn(object sender, EventArgs e) => Shell.Current.GoToAsync("pets/all");
}

