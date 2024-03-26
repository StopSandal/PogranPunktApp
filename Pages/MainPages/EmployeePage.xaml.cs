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
            <Label Text="Управление Сотрудниками"/>
            <VerticalStackLayout BackgroundColor="Blue"  HorizontalOptions="StartAndExpand" VerticalOptions="FillAndExpand">
                <Label Text="Регистрация пользователей в таблице колонка"/>
                <Label Text="Добавить Должность и изменить"  VerticalOptions="CenterAndExpand"/>
                <Label Text="Просмотреть список сотрудников"  VerticalOptions="CenterAndExpand"/>
            </VerticalStackLayout>
        </VerticalStackLayout>
        
        <VerticalStackLayout BackgroundColor="Red" VerticalOptions="EndAndExpand">
            <Label Text="График Дежурств"/>
            <Label Text="График Отчёт"/>
            <Label Text="Пормотреть"/>
            
            <Label Text="Просмотреть визулаьно для одного сотрудника???"/>
        </VerticalStackLayout>*/