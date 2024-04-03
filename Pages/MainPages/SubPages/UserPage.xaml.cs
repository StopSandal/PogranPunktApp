
using PogranPunktApp.Extensions.Listeners;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using Syncfusion.Maui.Core.Internals;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class UserPage : ContentPage
{
    UserDeleteListener listener;
	public UserPage()
	{
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new UserDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
        dataGrid.ItemsSource = new TableCollection<Users>(DBQuery.getAllTable("Select * from Users"));
	}
	private async void GoBack(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as Users).Id);
        }
    }
}