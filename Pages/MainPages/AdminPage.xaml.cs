using PogranPunktApp.Pages.MainPages.SubPages;

namespace PogranPunktApp.Pages.MainPages;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
	}
	private async void OpenUserPage(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new UserPage());
	}
	private async void OpenLogPage(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new LogPage());
    }
}