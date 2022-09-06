using Vet.Models;

namespace MauiVetApp.Views;

public partial class PetsPage : ContentPage
{
	public PetsPage()
	{
		InitializeComponent();
	}

	private async void PetsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		Pet pet = e.SelectedItem as Pet;
		
		await Shell.Current.GoToAsync($"pets/details?petId={pet.Id}");
	}
}