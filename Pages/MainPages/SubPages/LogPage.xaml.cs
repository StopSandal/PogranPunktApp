using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Inputs;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class LogPage : ContentPage
{
    private string tempFilterString = String.Empty;

    public LogPage()
	{
		InitializeComponent();
        var list = new List<string>();
        list.Add("D");
        list.Add("I");
        filterComboBox.ItemsSource = list;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateTable(null, null);
    }

    private async void goBack(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
    private void UpdateTable(object sender, EventArgs e)
    {
        this.dataGrid.ItemsSource = new TableCollection<���������Log>(DBQuery.getAllTable("Select ���������Log.*,������.�������� from ���������Log, ������ where ID_������=������.ID"));

    }
    private void FilterByName(object sender, EventArgs e)
    {
        tempFilterString = ((SfComboBox)sender).SelectedItem as string;
        FilterTable(sender, e);
    }
    private void FilterTable(object sender, EventArgs e)
    {

        dataGrid.View.Filter = FilterByName;
        dataGrid.View.RefreshFilter();

    }
    private bool FilterByName(object record)
    {
        ���������Log item = record as ���������Log;
        if (item is null)
            return false;
        if (String.IsNullOrEmpty(tempFilterString))
            return true;
        return item.LogType.Equals(tempFilterString);
    }
}