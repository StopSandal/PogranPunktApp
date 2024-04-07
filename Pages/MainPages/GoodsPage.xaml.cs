
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.Extensions.Reports;
using PogranPunktApp.Pages.MainPages.SubPages;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL.Tables.View;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages;

public partial class GoodsPage : ContentPage
{
	GoodsDeleteListener listener;
    private ������������� tempRowBuffer = null;
    private bool WasEdited = false;
    private int SelectedRowNumber = -1;
    public GoodsPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new GoodsDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        this.dataGrid.ItemsSource = new TableCollection<�������������>(DBQuery.getAllTable("Select * from �������������������� order by ���� Desc"));
        //
        (dataGrid.Columns["����������"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<�������>(DBQuery.getAllTable("select * from �������"))).Select(x => x.��������);

    }
    private async void OpenColumnDiagramPage(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new ColumnDiagramPage());
	}
    private async void OpenLineDiagramPage(object sender, EventArgs e)
	{
        await Navigation.PushModalAsync(new LineDiagramPage());
    }
	private void CreateYearReport(object sender, EventArgs e)
	{
		������YearReport.GenerateAllTimeReport(new TableCollection<�������������>(DBQuery.getAllTable("Select * from �������������������� order by ���� Desc")));
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as �������������).GetGoodID());
        }
    }
    private async void OpenGoodTypesPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GoodTypesPage());
    }
    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new �������������((sender as SfDataGrid).CurrentRow as �������������);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as �������������;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("�� ����� ������ ��������� ��������� ������?", $"��������!\n������ ������ \n{tempRowBuffer}\n\n\n����� ������ \n{TempRow}", "��", "���");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<�������������>(DBQuery.getAllTable("Select * from �������������������� order by ���� Desc"));
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
    private bool UpdateRow(������������� row)
    {
        return DBQuery.ChangeTable($"Update ������ Set {row.ToUpdateSetValuesString()}  where ID = {row.GetGoodID()}"); // use buffer 
    }
}