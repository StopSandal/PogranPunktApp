using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
		dataGrid.ItemsSource = new TableCollection<Users>(DBQuery.getAllTable("Select * from Users"));
	}
	private async void GoBack(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}