using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables.FunctionAdapter;
using Syncfusion.Maui.Charts;
using Syncfusion.Maui.DataGrid.Exporting;
using System.Runtime.Serialization;
#if WINDOWS
using PogranPunktApp.SupportClasses;
#endif
namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class ColumnDiagramPage : ContentPage
{
	public ColumnDiagramPage()
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
        var Table = new TableCollection<ColumnDiagramAdapter>(DBQuery.getAllTable("select Название, [dbo].[КолвоТоваровПоТипуПошлины](ID) as 'Count' from Пошлина order by Название"));
        ColumnSeries series = new ColumnSeries()
        {
            ItemsSource = Table,            
            ShowDataLabels = true,
            Label = "Количество",
            XBindingPath = "Name",
            YBindingPath = "Count",
            DataLabelSettings = new CartesianDataLabelSettings
            {
                LabelPlacement = DataLabelPlacement.Inner
            }
        };
        Diagram.Series.Add(series);
        dataGrid.ItemsSource = Table;
    }
    private void PopAsyncBack (object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private void ExportToExcel(object sender, EventArgs e)
    {
        
#if WINDOWS
        DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
        var excelEngine = excelExport.ExportToExcel(this.dataGrid,getDataGridExcelExportingOption());

        var workbook = excelEngine.Excel.Workbooks[0];
        MemoryStream stream = new MemoryStream();
        workbook.SaveAs(stream);
        workbook.Close();
        excelEngine.Dispose();

        string OutputFilename = $"Отчёт о перемещённых видах товаров за {DateTime.Now.ToShortDateString()}.xlsx";
        SaveService saveService = new();
        saveService.SaveAndView(OutputFilename, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", stream);
#endif

    }
    private DataGridExcelExportingOption getDataGridExcelExportingOption()
    {
        return new DataGridExcelExportingOption()
        {
            CanExportColumnWidth = true,
           // CanApplyGridStyle = true,
            CanExportHeader = true,
            
        };
    }
}