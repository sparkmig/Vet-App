using MauiVetApp.Models;
using Vet.Business.Pet;
using Vet.Models;

namespace MauiVetApp.Views;

public partial class CreateOrderPage : ContentPage
{
	public CreateOrderPage()
	{
		InitializeComponent();
	}

	private void AddTreatment_Clicked(object sender, EventArgs e)
	{
        var model = (CreateOrderPageModel)this.BindingContext;
		var selectedTreatment = (Treatment)this.Treatment_Picker.SelectedItem;
        model.TreatmentsAdded.Add(selectedTreatment);
    }

    private void Treatment_Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
        this.ChoosenTreatmentLabel.Text = "Beskrivelse: " + ((Treatment)Treatment_Picker.SelectedItem).Description;
    }

	private async void Save_btn_Clicked(object sender, EventArgs e)
	{
        CreateOrderPageModel model = (CreateOrderPageModel)this.BindingContext;
        Owner owner = (Owner)this.Owner_Picker.SelectedItem;

        await model.AddInvoice(owner.Id);
        await DisplayAlert("Success", "Faktura oprettet!", "OK");

        await Shell.Current.Navigation.PopAsync(true);
    }
}