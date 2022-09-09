using MauiVetApp.Models;
using Vet.Models;

namespace MauiVetApp.Views;

public partial class StatisticOverviewPage : ContentPage
{
	public StatisticOverviewPage()
	{
		InitializeComponent();
	}

	private void Treatment_Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var model = (StatisticOverviewPageModel)this.BindingContext;
        model.SelectedChanged();
	}

	private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
	{

	}
}