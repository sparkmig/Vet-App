using MauiVetApp.Models;

namespace MauiVetApp.Views;

public partial class ShowOrderPage : ContentPage
{
	public ShowOrderPage()
	{
		InitializeComponent();
	}

	private void Order_ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var model = (ShowOrderPageModel)this.BindingContext;
		 
		model.OnPropertyChanged(nameof(model.SelectedOrder));
	}
}