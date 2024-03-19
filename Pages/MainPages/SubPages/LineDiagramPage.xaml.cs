using PogranPunktApp.SQL.Tables.FunctionAdapter;
using PogranPunktApp.SQL;
using Syncfusion.Maui.Charts;
using Syncfusion.Maui.DataGrid.Exporting;
using PogranPunktApp.CustomComponents;

#if WINDOWS
using PogranPunktApp.SupportClasses;
#endif
namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class LineDiagramPage : ContentPage
{
    private TableCollection<LineDiagramAdapter> Table;
    public LineDiagramPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitDiagram();
    }
    private void InitDiagram()
    {
        Diagram.Series.Clear();
        Table = new TableCollection<LineDiagramAdapter>(DBQuery.getAllTable("exec ДанныеДляГрафика"));
        LineSeries series = new LineSeries()
        {
            ItemsSource = Table,
            ShowTrackballLabel = true,
            Label = "Сумма за один день",
            XBindingPath = "Дата",
            YBindingPath = "Цена",
            ShowMarkers = true,
            EnableTooltip = true,
        };
        Diagram.Series.Add(series);
        dataGrid.ItemsSource = Table.Where(x=> x.Цена!=0);
    }
    private void PopAsyncBack(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private void ExportToExcel(object sender, EventArgs e)
    {
#if WINDOWS
        DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
        var excelEngine = excelExport.ExportToExcel(this.dataGrid);
        var workbook = excelEngine.Excel.Workbooks[0];
        MemoryStream stream = new MemoryStream();
        workbook.SaveAs(stream);
        workbook.Close();
        excelEngine.Dispose();

        string OutputFilename = $"Отчёт о перемещённых товарах {DateTime.Now.ToShortDateString()}.xlsx";
        SaveService saveService = new();
        saveService.SaveAndView(OutputFilename, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", stream);
#endif
    }
    private void FilterDiagram(object sender, EventArgs e)
    {
        UnsetAllButtons();
        GraphicSelectorButton button = sender as GraphicSelectorButton;
        button.SelectButton();
        switch (button.DateFilter)
        {
            case CustomComponents.Enum.DateFilterEnum.Month:
                UpdateDataWithFilterOption( Table.Where(x => x.Дата.Month == DateTime.Now.Month && x.Дата.Year == Convert.ToInt32(YearLabel.Text)).ToList() );
                break;
            case CustomComponents.Enum.DateFilterEnum.Year:
                UpdateDataWithFilterOption(Table.Where(x => x.Дата.Year == Convert.ToInt32(YearLabel.Text)).ToList());
                break;
            case CustomComponents.Enum.DateFilterEnum.AllTime:
                UpdateDataWithFilterOption(Table); 
                break;
        }
    }
    private void UpdateDataWithFilterOption(IEnumerable<LineDiagramAdapter> tempData)
    {
        Diagram.Series.First().ItemsSource = tempData;
        dataGrid.ItemsSource = tempData.Where(x => x.Цена != 0);
    }

    private void UnsetAllButtons()
    {
        YearButton.UnselectButton();
        AllTimeButton.UnselectButton();
        MonthButton.UnselectButton();
    }

    private void DecrementButton(object sender, EventArgs e)
    {
        YearLabel.Text = (Convert.ToInt32(YearLabel.Text) - 1).ToString();
        UpdateDataWithFilterOption(Table.Where(x => x.Дата.Year == Convert.ToInt32(YearLabel.Text)).ToList());
        FilterDiagram(YearButton,e);
    }
    private void IncrementButton(object sender, EventArgs e)
    {
        YearLabel.Text = (Convert.ToInt32(YearLabel.Text) + 1).ToString();
        UpdateDataWithFilterOption(Table.Where(x => x.Дата.Year == Convert.ToInt32(YearLabel.Text)).ToList());
        FilterDiagram(YearButton, e);
    }

}