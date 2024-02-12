namespace PogranPunktApp.Pages;

public partial class MainMenuPage : ContentPage
{
	public MainMenuPage()
	{
		InitializeComponent();
	}
	private void ExitButtonHandler(object sender, EventArgs e)
	{
        App.Current.MainPage = new AutorizationPage();
		UserInfo.UserInfo.UnloginUser();
    }
}