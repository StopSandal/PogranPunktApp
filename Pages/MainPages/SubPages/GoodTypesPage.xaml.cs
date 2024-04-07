using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class GoodTypesPage : ContentPage
{
    TypeGDeleteListener listener;
    private ������� tempRowBuffer = null;
    private bool WasEdited = false;
    private int SelectedRowNumber = -1;
    public GoodTypesPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new TypeGDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
        dataGrid.ItemsSource = new TableCollection<�������>(DBQuery.getAllTable("Select * from �������"));
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as �������).ID);
        }
    }
    private void dataGrid_CurrentCellBeginEdit(object sender, DataGridCurrentCellBeginEditEventArgs e)
    {
        if (tempRowBuffer is null)
        {
            SelectedRowNumber = (sender as SfDataGrid).SelectedIndex;
            tempRowBuffer = new �������((sender as SfDataGrid).CurrentRow as �������);
            WasEdited = true;
        }
    }


    private async void dataGrid_SelectionChanging(object sender, DataGridSelectionChangingEventArgs e)
    {
        if (WasEdited)
        {
            var TempRow = (sender as SfDataGrid).SelectedRow as �������;

            if (!TempRow.Equals(tempRowBuffer))
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("�� ����� ������ ��������� ��������� ������?", $"��������!\n������ ������ \n{tempRowBuffer}\n\n\n����� ������ \n{TempRow}", "��", "���");
                if (choice)
                {
                    UpdateRow(TempRow);
                    this.dataGrid.ItemsSource = new TableCollection<�������>(DBQuery.getAllTable("Select * from �������"));
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
    private bool UpdateRow(������� row)
    {
        return DBQuery.ChangeTable($"Update ������� Set {row.ToUpdateSetValuesString()}  where ID = {row.ID}"); // use buffer 
    }
}