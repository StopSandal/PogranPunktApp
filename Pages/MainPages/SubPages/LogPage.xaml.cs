using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class LogPage : ContentPage
{
	public LogPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		dataGrid.ItemsSource = new TableCollection<���������Log>(DBQuery.getAllTable("Select * from ���������Log"));
    }

    private async void goBack(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}