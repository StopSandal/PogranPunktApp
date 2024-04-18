using PogranPunktApp.Pages.MainPages;
using PogranPunktApp.Pages.MainPages.SubPages;
using PogranPunktApp.SQL;

namespace PogranPunktApp.Pages;

public partial class MainMenuPage : ContentPage
{
    public MainMenuPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Unfocus();
        if ( Convert.ToBoolean(DBQuery.getAllTable($"select dbo.InformAboutPassword('{UserInfo.UserInfo.UserLogin}')").Rows[0][0]) )
        {
            ChangePasswordRemainder.IsVisible = true;  
        }
        if (UserInfo.UserInfo.LevelOfRules!=UserInfo.Roles.Admin)
            LogAdminStack.IsVisible = false;
        userLoginLable.Text = "������������: " + UserInfo.UserInfo.UserName;
        levelLable.Text = "������� �������: " + UserInfo.RolesMethods.RolesToString(UserInfo.UserInfo.LevelOfRules);
        stackRoutes.Focus();
    }

    private async void ToEmployeePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmployeePage());
    }
    private async void ToRoutesPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoutesPage());
    }
    private async void ToAutoPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AutoPage());
    }
    private async void ToCivilianPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CivilianPage());
    }
    private async void ToGoodsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GoodsPage());
    }
    private async void OpenAdminPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminPage());
    }
    private void OnButtonHover(object sender, EventArgs e)
    {
        ((ImageButton)sender).Shadow = new Shadow();
    }
    private void OnButtonUnhover(object sender, EventArgs e)
    {

        ((ImageButton)sender).Shadow = new Shadow()
        {
            Opacity = 0
        };
    }

    private async void ExitButtonHandler(object sender, EventArgs e)
    {
        UserInfo.UserInfo.UnloginUser();
        await Navigation.PopAsync();

    }
    private async void OpenChangePassword(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ChangePasswordPage());
    }
}