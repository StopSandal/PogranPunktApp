using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class LogPage : ContentPage
{
	public LogPage()
	{
		InitializeComponent();
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
}