
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.Pages.MainPages.SubPages;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;

namespace PogranPunktApp.Pages.MainPages;

public partial class EmployeePage : ContentPage
{
    EmployeeDeleteListener listener;
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
}
