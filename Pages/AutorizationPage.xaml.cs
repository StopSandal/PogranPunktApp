
using CommunityToolkit.Maui.Views;
using Microsoft.Data.SqlClient;
using PogranPunktApp.Extensions;
using PogranPunktApp.Popups;
using PogranPunktApp.SQL;
using System.Runtime.CompilerServices;
namespace PogranPunktApp.Pages;

public partial class AutorizationPage : ContentPage
{
    

    public AutorizationPage()
    {
		InitializeComponent();
		InitListeners();
    }

	private void InitListeners()
	{
		loginEntry.Completed += nextPasswordEntry;
		passwordEntry.Completed += startLogin;
    }
	private void nextPasswordEntry(object sender, EventArgs e)
	{
		passwordEntry.Focus();
	}
	private void startLogin(object sender, EventArgs e)
	{
		passwordEntry.Unfocus();
		AutorizationButton_Click(sender, e);
	}
	private async void AutorizationButton_Click(object sender, EventArgs e)
	{
		if(loginEntry.Text == null || passwordEntry.Text == null){
			await DisplayAlert("Ошибка","Заполните Табельный номер и Пароль","Закрыть");
			return;
		}
		
		bool IsNoConnection = false;
        DBInfo.IsTryReconnect = true;
		do
		{
            Popup popup = new WaitingPopup() { CanBeDismissedByTappingOutsideOfPopup = false };
            this.ShowPopup(popup);
			await Task.Run( () =>
			{
				if (!DBQuery.EstablishSQLDatabaseConnection())
					if (!DBInfo.IsTryReconnect)
					{
						IsNoConnection = true;	
						return;
					}
			});
            popup.Close();
        }
		while (DBInfo.IsTryReconnect);

		if (IsNoConnection)
			return;

        if (CheckUser(loginEntry.Text, passwordEntry.Text))
		{
			App.Current.MainPage = new MainMenuPage();
		}
		//Добавить логирование неудач входа 
	}

	private bool CheckUser(string username, string password)
	{


        if (!UserInfo.UserInfo.ParseUser( DBQuery.getUserInfo(username) , password))
		{
            DisplayAlert("Ошибка", "Неверный логин или пароль","Закрыть");
            return false;
        }
		if (UserInfo.UserInfo.IsLogin())
			return true;
		return false;

	}
}