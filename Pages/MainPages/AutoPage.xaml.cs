using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables.SubTable;
using Syncfusion.Maui.Core.Internals;
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.Pages.MainPages.SubPages;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages;

public partial class AutoPage : ContentPage
{
    private РасширениеАвтомобильМодель tempRowBuffer = null;
    private bool WasEdited = false;
    private int SelectedRowNumber = -1;
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

        dataGrid.ItemsSource = new TableCollection<РасширениеАвтомобильМодель>(DBQuery.getAllTable($"select * from Автомобиль,ВидыТранспорта where ID_Вида=ВидыТранспорта.ID"));
        (dataGrid.Columns["ВидТранспорта"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<ВидыТранспорта>(DBQuery.getAllTable("select * from ВидыТранспорта"))).Select(x => x.Название);
    }
    private void SelectedRow(object sender, EventArgs e)
	{
		if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex>0) {
			listener.SetID((dataGrid.SelectedRow as РасширениеАвтомобильМодель).ID);
		}
	}
	private async void OpenModelsPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ModelsPage());
	}


    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new РасширениеАвтомобильМодель((sender as SfDataGrid).CurrentRow as РасширениеАвтомобильМодель);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as РасширениеАвтомобильМодель;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("Вы точно хотите применить изменения записи?", $"Внимание!\nСтарые Данные \n{tempRowBuffer}\n\n\nНовые Данные \n{TempRow}", "Да", "Нет");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<РасширениеАвтомобильМодель>(DBQuery.getAllTable($"select * from Автомобиль,ВидыТранспорта where ID_Вида=ВидыТранспорта.ID"));
                    tempRowBuffer = null;
                }
                else
                {
                    (sender as SfDataGrid).SelectedIndex = SelectedRowNumber;
                    e.Cancel = true;
                    return;
                }
            }
        }
        WasEdited = false;
        tempRowBuffer = null;
    }
    private bool UpdateRow(РасширениеАвтомобильМодель row)
    {
        return DBQuery.ChangeTable($"Update Автомобиль Set {row.ToUpdateSetValuesString()}  where ID = {row.ID}"); 
    }
}