using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class CountriesPage : ContentPage
{
    CivilDeleteListener listener;
    public CountriesPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new CivilDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
        dataGrid.ItemsSource = new TableCollection<Страны>(DBQuery.getAllTable("Select * from Страны"));
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as Страны).ID);
        }
    }
}