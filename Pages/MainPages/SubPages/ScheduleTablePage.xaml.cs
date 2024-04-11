using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class ScheduleTablePage : ContentPage
{
    private ДежурныйСотрудник tempRowBuffer = null;
    private bool WasEdited = false;
    private int SelectedRowNumber = -1;
    ScheduleDeleteListener listener;
    public ScheduleTablePage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new ScheduleDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateTable(null, null);
    }

    private void UpdateTable(object sender, EventArgs e)
    {
        this.dataGrid.ItemsSource = new TableCollection<ДежурныйСотрудник>(DBQuery.getAllTable($"Select Дежурства.ID,ФИО,Дата_Рождения,Название,ДатаВремя_Конца,ДатаВремя_Начала,Сотрудники.ID as 'ID_Сотрудника' from Дежурства,Сотрудники,Должность where  Сотрудники.ID=Дежурства.ID_Сотрудника and ID_Должности=Должность.ID"));
    }

    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new ДежурныйСотрудник((sender as SfDataGrid).CurrentRow as ДежурныйСотрудник);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as ДежурныйСотрудник;

            if (TempRow != tempRowBuffer)
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("Вы точно хотите применить изменения записи?", $"Внимание!\nСтарые Данные \n{tempRowBuffer}\n\n\nНовые Данные \n{TempRow}", "Да", "Нет");
                if (choice)
                {
                    UpdateRow(TempRow);
                    UpdateTable(sender, e);
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
    private bool UpdateRow(ДежурныйСотрудник row)
    {
        return DBQuery.ChangeTable($"Update Дежурства Set {row.ToUpdateSetValuesString()}  where ID = {row.GetID()}"); // use buffer 
    }
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as ДежурныйСотрудник).GetID());
        }
    }
}