
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
    private ������������������ tempRowBuffer = null;
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
        (dataGrid.Columns["�����������������"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<���������>(DBQuery.getAllTable("select * from ���������"))).Select(x => x.��������);

        dataGrid.ItemsSource = new TableCollection<������������������>(DBQuery.getAllTable("select * from ������������������"));
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

        
        int Count = (int)DBQuery.getAllTable("exec dbo.�������������������������������").Rows[0][0];
        if(Count == 0)
        {
            await this.DisplayAlert("����������� ���������", "��� ���������� � ��� ���������������", "�������");
            return;
        }
          await this.DisplayAlert("����������� ���������", $"���� ���������������� {Count} �����������", "�������");
          OnAppearing();
    }
    private async void OpenDutySchedule(object sender, EventArgs e) {
        await Navigation.PushAsync(new SchedulePage());
    }
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as ������������������).getID());
        }
    }
    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new ������������������((sender as SfDataGrid).CurrentRow as ������������������);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as ������������������;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("�� ����� ������ ��������� ��������� ������?", $"��������!\n������ ������ \n{tempRowBuffer}\n\n\n����� ������ \n{TempRow}", "��", "���");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<������������������>(DBQuery.getAllTable("select * from ������������������"));
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
    private bool UpdateRow(������������������ row)
    {
        return DBQuery.ChangeTable($"Update ���������� Set {row.ToUpdateSetValuesString()}  where ID = {row.getID()}");
    }
    private void UpdateTable(object sender, EventArgs e)
    {
        this.dataGrid.ItemsSource = new TableCollection<������������������>(DBQuery.getAllTable("select * from ������������������"));

    }
}
