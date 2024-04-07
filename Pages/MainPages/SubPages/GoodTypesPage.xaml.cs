using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class GoodTypesPage : ContentPage
{
    TypeGDeleteListener listener;
    private Пошлина tempRowBuffer = null;
    private bool WasEdited = false;
    private int SelectedRowNumber = -1;
    public GoodTypesPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new TypeGDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
        dataGrid.ItemsSource = new TableCollection<Пошлина>(DBQuery.getAllTable("Select * from Пошлина"));
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as Пошлина).ID);
        }
    }
    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new Пошлина((sender as SfDataGrid).CurrentRow as Пошлина);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as Пошлина;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("Вы точно хотите применить изменения записи?", $"Внимание!\nСтарые Данные \n{tempRowBuffer}\n\n\nНовые Данные \n{TempRow}", "Да", "Нет");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<Пошлина>(DBQuery.getAllTable("Select * from Пошлина"));
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
    private bool UpdateRow(Пошлина row)
    {
        return DBQuery.ChangeTable($"Update Пошлина Set {row.ToUpdateSetValuesString()}  where ID = {row.ID}"); // use buffer 
    }
}