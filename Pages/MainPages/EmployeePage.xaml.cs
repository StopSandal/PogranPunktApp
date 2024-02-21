namespace PogranPunktApp.Pages.MainPages;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
	}
	private async void Back(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}