using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class ModelsPage : ContentPage
{
	public ModelsPage()
	{
		InitializeComponent();
		dataGrid.ItemsSource = new TableCollection<��������������>(DBQuery.getAllTable("Select * from ��������������"));
	}
}