using MauiVetApp.Models;
using Vet.Models;

namespace MauiVetApp.Views;

public partial class PetDetailsPage : ContentPage
{
    public PetDetailsPage()
    {
        InitializeComponent();
    }

    private void CreateOrder_Button_Clicked(object sender, EventArgs e)
    {
        var details = (PetDetailsPageModel)BindingContext;
        Shell.Current.GoToAsync("pets/createOrder?petId=" + details.Pet.Id);
    }

    private void ShowOrders_Button_Clicked(object sender, EventArgs e)
    {
        var details = (PetDetailsPageModel)BindingContext;
        Shell.Current.GoToAsync("pets/showOrders?petId=" + details.Pet.Id);
    }
}