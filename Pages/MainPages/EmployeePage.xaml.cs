
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.Pages.MainPages.SubPages;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL.Tables.SubTable;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages;

public partial class EmployeePage : ContentPage
{
    EmployeeDeleteListener listener;
    private ОтделКадровТаблица tempRowBuffer = null;
    private bool WasEdited = false;
    private int SelectedRowNumber = -1;
    public EmployeePage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new EmployeeDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (dataGrid.Columns["НазваниеДолжности"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<Должность>(DBQuery.getAllTable("select * from Должность"))).Select(x => x.Название);

        dataGrid.ItemsSource = new TableCollection<ОтделКадровТаблица>(DBQuery.getAllTable("select * from ОтделКадровТаблица"));
    }
    private async void Back(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
    private async void OpenPositionPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PositionPage());
    }
    private async void RegistrationAllUnregisteredEmployees(object sender, EventArgs e)
    {

        
        int Count = (int)DBQuery.getAllTable("exec dbo.ЗарегистрироватьВсехСотрудников").Rows[0][0];
        if(Count == 0)
        {
            await this.DisplayAlert("Регистрация аккаунтов", "Все сотрудники и так зарегистированы", "Закрыть");
            return;
        }
          await this.DisplayAlert("Регистрация аккаунтов", $"Было зарегистрировано {Count} сотрудников", "Закрыть");
          OnAppearing();
    }
    private async void OpenDutySchedule(object sender, EventArgs e) {
        await Navigation.PushAsync(new SchedulePage());
    }
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as ОтделКадровТаблица).getID());
        }
    }
    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new ОтделКадровТаблица((sender as SfDataGrid).CurrentRow as ОтделКадровТаблица);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as ОтделКадровТаблица;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("Вы точно хотите применить изменения записи?", $"Внимание!\nСтарые Данные \n{tempRowBuffer}\n\n\nНовые Данные \n{TempRow}", "Да", "Нет");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<ОтделКадровТаблица>(DBQuery.getAllTable("select * from ОтделКадровТаблица"));
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
    private bool UpdateRow(ОтделКадровТаблица row)
    {
        return DBQuery.ChangeTable($"Update Сотрудники Set {row.ToUpdateSetValuesString()}  where ID = {row.getID()}");
    }
    private void UpdateTable(object sender, EventArgs e)
    {
        this.dataGrid.ItemsSource = new TableCollection<ОтделКадровТаблица>(DBQuery.getAllTable("select * from ОтделКадровТаблица"));

    }
}
