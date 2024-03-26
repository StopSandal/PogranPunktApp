
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages;

public partial class CivilianPage : ContentPage
{

	private string tempNameFilterString=String.Empty;
	private string tempPassportFilterString = String.Empty;
	private ГражданинСтраны tempRowBuffer = null;
	private bool WasEdited = false;
	private int SelectedRowNumber = -1;

	public CivilianPage()
	{
		InitializeComponent();
		

        this.dataGrid.ItemsSource = new TableCollection<ГражданинСтраны>(DBQuery.getAllTable("select Гражданин.*, Название from Гражданин, Страны where ID_Страны=Страны.ID"));
		(dataGrid.Columns["Страна"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<Страны>(DBQuery.getAllTable("select ID,Название from Страны"))).Select(x=>x.Название);

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

    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
		if (tempRowBuffer is null)
		{
			SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
			tempRowBuffer = new ГражданинСтраны((sender as SfDataGrid).CurrentRow as ГражданинСтраны); // can bug if row current wrong| to solve add setter in EndEditEvent
			WasEdited = true;
		}
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
		if(WasEdited )
		{
			var TempRow = (sender as SfDataGrid).SelectedRow as ГражданинСтраны;

            if (TempRow != tempRowBuffer)
			{
				bool choice = await Application.Current.MainPage.DisplayAlert("Вы точно хотите применить изменения записи?", $"Внимание!\nСтарые Данные \n{tempRowBuffer}\n\n\nНовые Данные \n{TempRow}", "Да", "Нет");
				if(choice)
				{
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<ГражданинСтраны>(DBQuery.getAllTable("select Гражданин.*, Название from Гражданин, Страны where ID_Страны=Страны.ID"));
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
	private bool UpdateRow(ГражданинСтраны row)
	{
		return DBQuery.ChangeTable($"Update Гражданин Set {row.ToUpdateSetValuesString()}  where ID = {row.GetID()}"); // use buffer 
	}
}