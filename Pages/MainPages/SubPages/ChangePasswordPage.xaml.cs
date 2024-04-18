namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class ChangePasswordPage : ContentPage
{
	public ChangePasswordPage()
	{
		InitializeComponent();
	}
    private async void goBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}