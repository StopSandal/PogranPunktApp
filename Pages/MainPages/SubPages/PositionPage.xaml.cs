using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class PositionPage : ContentPage
{
	public PositionPage()
	{
		InitializeComponent();
		dataGrid.ItemsSource = new TableCollection<Должность>(DBQuery.getAllTable("Select * from Должность"));
	}
}