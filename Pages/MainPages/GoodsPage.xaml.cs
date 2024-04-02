
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
		this.dataGrid.ItemsSource = new TableCollection<�������������>(DBQuery.getAllTable("Select * from �������������������� order by ���� Desc"));
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
		������YearReport.GenerateAllTimeReport(new TableCollection<�������������>(DBQuery.getAllTable("Select * from �������������������� order by ���� Desc")));
	}
}