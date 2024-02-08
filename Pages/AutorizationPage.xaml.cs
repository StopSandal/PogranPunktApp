
namespace PogranPunktApp.Pages;

public partial class AutorizationPage : ContentPage
{
	public AutorizationPage()
	{
		InitializeComponent();
	}

    private void AutorizationButton_Click(object sender, EventArgs e)
    {
        UserInfo.UserInfo.LoginUser("Admin", "Admin'sLogin", UserInfo.Roles.Admin);
		//UserInfo.UserInfo.UnloginUser();
        if (CheckUser(loginEntry.Text,passwordEntry.Text)) {
			App.Current.MainPage = new MainMenuPage();
			
		}
		else
            DisplayAlert("Поздравляю!", "Ты прошёл проверку, товарищ.\nТы готов служить Родине и Стране. За Родину, За Республику оф Беларусь!\n\n Я получил повестку и готов пройти в военкомат " + DateTime.Now, "Согласен на СБО");
			//Добавить логирование неудач входа
    }
    private void EstablishSQLDatabaseConnection(string path)
	{

	}
	private bool CheckUser(string username,string password) {
		if (UserInfo.UserInfo.IsLogin())
			return true;
		return false;
	}
}