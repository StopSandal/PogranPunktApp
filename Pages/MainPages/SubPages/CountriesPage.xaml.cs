using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class CountriesPage : ContentPage
{
	public CountriesPage()
	{
		InitializeComponent();
		dataGrid.ItemsSource = new TableCollection<������>(DBQuery.getAllTable("Select * from ������"));
	}
}