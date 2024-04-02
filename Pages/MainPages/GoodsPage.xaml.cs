
using PogranPunktApp.Extensions.Reports;
using PogranPunktApp.Pages.MainPages.SubPages;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables.View;

namespace PogranPunktApp.Pages.MainPages;

public partial class GoodsPage : ContentPage
{

	public GoodsPage()
	{
		InitializeComponent();
		this.dataGrid.ItemsSource = new TableCollection<ТоварыТаблица>(DBQuery.getAllTable("Select * from ТоварыПоПеремещениям order by Дата Desc"));
		//mainLayout.Children.Add();
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
}