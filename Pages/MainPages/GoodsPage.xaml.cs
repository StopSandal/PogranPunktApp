
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.Extensions.Reports;
using PogranPunktApp.Pages.MainPages.SubPages;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL.Tables.View;
using Syncfusion.Maui.Core.Internals;

namespace PogranPunktApp.Pages.MainPages;

public partial class GoodsPage : ContentPage
{
	GoodsDeleteListener listener;
	public GoodsPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new GoodsDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
        this.dataGrid.ItemsSource = new TableCollection<ТоварыТаблица>(DBQuery.getAllTable("Select * from ТоварыПоПеремещениям order by Дата Desc"));
        

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
}