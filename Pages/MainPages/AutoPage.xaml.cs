using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables.SubTable;
using Syncfusion.Maui.Core.Internals;
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.Pages.MainPages.SubPages;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages;

public partial class AutoPage : ContentPage
{
    private �������������������������� tempRowBuffer = null;
    private bool WasEdited = false;
    private int SelectedRowNumber = -1;
    private AutomobileDeleteListener listener;
	public AutoPage()
	{
		InitializeComponent();
 
	    
		dataGrid.ClearKeyboardListeners();
		listener = new AutomobileDeleteListener(-1,dataGrid);
		dataGrid.AddKeyboardListener(listener);
	
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        dataGrid.ItemsSource = new TableCollection<��������������������������>(DBQuery.getAllTable($"select * from ����������,�������������� where ID_����=��������������.ID"));
        (dataGrid.Columns["�������������"] as DataGridComboBoxColumn).ItemsSource = (new TableCollection<��������������>(DBQuery.getAllTable("select * from ��������������"))).Select(x => x.��������);
    }
    private void SelectedRow(object sender, EventArgs e)
	{
		if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex>0) {
			listener.SetID((dataGrid.SelectedRow as ��������������������������).ID);
		}
	}
	private async void OpenModelsPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ModelsPage());
	}


    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new ��������������������������((sender as SfDataGrid).CurrentRow as ��������������������������);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as ��������������������������;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("�� ����� ������ ��������� ��������� ������?", $"��������!\n������ ������ \n{tempRowBuffer}\n\n\n����� ������ \n{TempRow}", "��", "���");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<��������������������������>(DBQuery.getAllTable($"select * from ����������,�������������� where ID_����=��������������.ID"));
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
    private bool UpdateRow(�������������������������� row)
    {
        return DBQuery.ChangeTable($"Update ���������� Set {row.ToUpdateSetValuesString()}  where ID = {row.ID}"); 
    }
    private void UpdateTable(object sender, EventArgs e)
    {
        this.dataGrid.ItemsSource = new TableCollection<��������������������������>(DBQuery.getAllTable($"select * from ����������,�������������� where ID_����=��������������.ID"));

    }
}