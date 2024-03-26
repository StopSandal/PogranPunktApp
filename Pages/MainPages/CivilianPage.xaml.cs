
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages;

public partial class CivilianPage : ContentPage
{

	private string tempNameFilterString=String.Empty;
	private string tempPassportFilterString = String.Empty;
	private ��������������� tempRowBuffer = null;
	private bool WasEdited = false;
	private int SelectedRowNumber = -1;

	public CivilianPage()
	{
		InitializeComponent();
		

        this.dataGrid.ItemsSource = new TableCollection<���������������>(DBQuery.getAllTable("select ���������.*, �������� from ���������, ������ where ID_������=������.ID"));
		(dataGrid.Columns["������"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<������>(DBQuery.getAllTable("select ID,�������� from ������"))).Select(x=>x.��������);

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

    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
		if (tempRowBuffer is null)
		{
			SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
			tempRowBuffer = new ���������������((sender as SfDataGrid).CurrentRow as ���������������); // can bug if row current wrong| to solve add setter in EndEditEvent
			WasEdited = true;
		}
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
		if(WasEdited )
		{
			var TempRow = (sender as SfDataGrid).SelectedRow as ���������������;

            if (TempRow != tempRowBuffer)
			{
				bool choice = await Application.Current.MainPage.DisplayAlert("�� ����� ������ ��������� ��������� ������?", $"��������!\n������ ������ \n{tempRowBuffer}\n\n\n����� ������ \n{TempRow}", "��", "���");
				if(choice)
				{
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<���������������>(DBQuery.getAllTable("select ���������.*, �������� from ���������, ������ where ID_������=������.ID"));
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
	private bool UpdateRow(��������������� row)
	{
		return DBQuery.ChangeTable($"Update ��������� Set {row.ToUpdateSetValuesString()}  where ID = {row.GetID()}"); // use buffer 
	}
}