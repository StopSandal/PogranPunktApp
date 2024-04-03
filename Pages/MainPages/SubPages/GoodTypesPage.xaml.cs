using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class GoodTypesPage : ContentPage
{
    TypeGDeleteListener listener;
	public GoodTypesPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new TypeGDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
        dataGrid.ItemsSource = new TableCollection<�������>(DBQuery.getAllTable("Select * from �������"));
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as �������).ID);
        }
    }
}