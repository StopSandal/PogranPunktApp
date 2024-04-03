using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables.SubTable;
using Syncfusion.Maui.Core.Internals;
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.Pages.MainPages.SubPages;

namespace PogranPunktApp.Pages.MainPages;

public partial class AutoPage : ContentPage
{

	private AutomobileDeleteListener listener;
	public AutoPage()
	{
		InitializeComponent();
 
	    
		dataGrid.ClearKeyboardListeners();
		listener = new AutomobileDeleteListener(-1,dataGrid);
		dataGrid.AddKeyboardListener(listener);
	
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        dataGrid.ItemsSource = new TableCollection<–асширениејвтомобильћодель>(DBQuery.getAllTable($"select * from јвтомобиль,¬иды“ранспорта where ID_¬ида=¬иды“ранспорта.ID"));

    }
    private void SelectedRow(object sender, EventArgs e)
	{
		if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex>0) {
			listener.SetID((dataGrid.SelectedRow as –асширениејвтомобильћодель).ID);
		}
	}
	private async void OpenModelsPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ModelsPage());
	}
}