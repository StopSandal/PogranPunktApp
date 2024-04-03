using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class PositionPage : ContentPage
{
    PositionDeleteListener listener;
	public PositionPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new PositionDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
        dataGrid.ItemsSource = new TableCollection<Должность>(DBQuery.getAllTable("Select * from Должность"));
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as Должность).getID());
        }
    }
}