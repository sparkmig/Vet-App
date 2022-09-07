using MauiVetApp.Models;
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
		this.ChoosenTreatmentLabel.Text = ((Treatment)Treatment_Picker.SelectedItem).Description;
	}
}