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

/*
 *      <VerticalStackLayout BackgroundColor="NavajoWhite" HorizontalOptions="CenterAndExpand">
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