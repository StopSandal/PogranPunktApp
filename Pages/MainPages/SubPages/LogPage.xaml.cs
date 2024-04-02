namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class LogPage : ContentPage
{
	public LogPage()
	{
		InitializeComponent();
	}
	private async void goBack(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}