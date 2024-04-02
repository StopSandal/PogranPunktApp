using PogranPunktApp.Pages.MainPages;

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
        if (UserInfo.UserInfo.LevelOfRules!=UserInfo.Roles.Admin)
            LogAdminStack.IsVisible = false;
        userLoginLable.Text = "Пользователь: " + UserInfo.UserInfo.UserName;
        levelLable.Text = "Уровень доступа: " + UserInfo.RolesMethods.RolesToString(UserInfo.UserInfo.LevelOfRules);
    }
    private void InitOnStart()
    {

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

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {

    }
}