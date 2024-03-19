
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
		

        this.dataGrid.ItemsSource = new TableCollection<���������>(DBQuery.getAllTable("select * from ���������"));
		(dataGrid.Columns["Id������"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<������>(DBQuery.getAllTable("select ID,�������� from ������"))).Select(x=>x.��������);

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
		��������� item =  record as ���������;
		return item.���.StartsWith(tempNameFilterString,StringComparison.CurrentCultureIgnoreCase) 
			   && item.�������������.StartsWith(tempPassportFilterString, StringComparison.CurrentCultureIgnoreCase);
	}
	private void RefreshDataGrid(object sender, EventArgs e)
	{
		dataGrid.View.Refresh();
	}
}