using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class GoodTypesPage : ContentPage
{
	public GoodTypesPage()
	{
		InitializeComponent();
		dataGrid.ItemsSource = new TableCollection<�������>(DBQuery.getAllTable("Select * from �������"));
	}
}