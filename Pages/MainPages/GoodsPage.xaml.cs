
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
    private ТоварыТаблица tempRowBuffer = null;
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

        this.dataGrid.ItemsSource = new TableCollection<ТоварыТаблица>(DBQuery.getAllTable("Select * from ТоварыПоПеремещениям order by Дата Desc"));
        //
        (dataGrid.Columns["ВидПошлины"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<Пошлина>(DBQuery.getAllTable("select * from Пошлина"))).Select(x => x.Название);

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
		ТоварыYearReport.GenerateAllTimeReport(new TableCollection<ТоварыТаблица>(DBQuery.getAllTable("Select * from ТоварыПоПеремещениям order by Дата Desc")));
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as ТоварыТаблица).GetGoodID());
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
            tempRowBuffer = new ТоварыТаблица((sender as SfDataGrid).CurrentRow as ТоварыТаблица);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as ТоварыТаблица;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("Вы точно хотите применить изменения записи?", $"Внимание!\nСтарые Данные \n{tempRowBuffer}\n\n\nНовые Данные \n{TempRow}", "Да", "Нет");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<ТоварыТаблица>(DBQuery.getAllTable("Select * from ТоварыПоПеремещениям order by Дата Desc"));
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
    private bool UpdateRow(ТоварыТаблица row)
    {
        return DBQuery.ChangeTable($"Update Товары Set {row.ToUpdateSetValuesString()}  where ID = {row.GetGoodID()}"); // use buffer 
    }
}