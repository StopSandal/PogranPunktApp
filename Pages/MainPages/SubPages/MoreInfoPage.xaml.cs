using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class MoreInfoPage : ContentPage
{
	private int ID;
	public MoreInfoPage(int id)
	{
		InitializeComponent();
		ID = id;
        TestLabel.Text = "Информация о перемещении зарегистрированном " + DBQuery.getAllTable($"Select Дата from Перемещения where ID={ID}").Rows[0]["Дата"].ToString();
        Civilian.ItemsSource = new TableCollection<ГражданинСтраны>(DBQuery.getAllTable($"select * from Гражданин,Страны where Гражданин.ID=(Select ID_Гражданина from Перемещения where ID={ID}) and ID_Страны=Страны.ID"));
        Automobile.ItemsSource = new TableCollection<АвтомобильМодель>(DBQuery.getAllTable($"select * from Автомобиль,ВидыТранспорта where Автомобиль.ID=(Select ID_Автомобиля from Перемещения where ID={ID}) and ID_Вида=ВидыТранспорта.ID"));
        Employee.ItemsSource = new TableCollection<ДежурныйСотрудник>(DBQuery.getAllTable($"select * from [dbo].СотрудникДежурныйПоПеремещению({ID})"));
        Goods.ItemsSource = new TableCollection<ТоварыПошлина>(DBQuery.getAllTable($"Select * from ТоварыПоПеремещениям where ID_Перемещения={ID}"));

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
       //Select * from ТоварыПоПеремещениям
    }

    private async void Back(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}