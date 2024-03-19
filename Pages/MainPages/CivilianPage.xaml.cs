
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages;

public partial class CivilianPage : ContentPage
{

	private string tempNameFilterString=String.Empty;
	private string tempPassportFilterString = String.Empty;
	public CivilianPage()
	{
		InitializeComponent();
		

        this.dataGrid.ItemsSource = new TableCollection<Гражданин>(DBQuery.getAllTable("select * from Гражданин"));
		(dataGrid.Columns["IdСтраны"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<Страны>(DBQuery.getAllTable("select ID,Название from Страны"))).Select(x=>x.Название);

    }
	private void FilterByName(object sender,EventArgs e)
	{
        tempNameFilterString = ((Entry)sender).Text;
		FilterTable(sender, e);
    }
    private void FilterByPassport(object sender, EventArgs e)
    {
        tempPassportFilterString = ((Entry)sender).Text;
        FilterTable(sender, e);
    }
    private void FilterTable(object sender, EventArgs e)
	{
		
        dataGrid.View.Filter = FilterByName;
        dataGrid.View.RefreshFilter();

	}
	private bool FilterByName(object record)
	{
		Гражданин item =  record as Гражданин;
		return item.ФИО.StartsWith(tempNameFilterString,StringComparison.CurrentCultureIgnoreCase) 
			   && item.НомерПаспорта.StartsWith(tempPassportFilterString, StringComparison.CurrentCultureIgnoreCase);
	}
	private void RefreshDataGrid(object sender, EventArgs e)
	{
		dataGrid.View.Refresh();
	}
}