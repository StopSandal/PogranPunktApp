using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
        

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        dataGrid.ItemsSource = new TableCollection<������������������>(DBQuery.getAllTable("select * from ������������������"));
    }
    private async void Back(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
    private async void OpenPositionPage(object sender, EventArgs e)
    {

    }
    private void RegistrationAllUnregisteredEmployees(object sender, EventArgs e)
    {

    }
}

/*    <VerticalStackLayout BackgroundColor="NavajoWhite" HorizontalOptions="CenterAndExpand">
            <Label Text="���������� ������������"/>
            <VerticalStackLayout BackgroundColor="Blue"  HorizontalOptions="StartAndExpand" VerticalOptions="FillAndExpand">
                <Label Text="����������� ������������� � ������� �������"/>
                <Label Text="�������� ��������� � ��������"  VerticalOptions="CenterAndExpand"/>
                <Label Text="����������� ������ �����������"  VerticalOptions="CenterAndExpand"/>
            </VerticalStackLayout>
        </VerticalStackLayout>
        
        <VerticalStackLayout BackgroundColor="Red" VerticalOptions="EndAndExpand">
            <Label Text="������ ��������"/>
            <Label Text="������ �����"/>
            <Label Text="����������"/>
            
            <Label Text="����������� ��������� ��� ������ ����������???"/>
        </VerticalStackLayout>*/