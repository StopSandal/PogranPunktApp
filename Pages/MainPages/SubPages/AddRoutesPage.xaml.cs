using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL.Tables.FunctionAdapter;
using PogranPunktApp.SQL.Tables.SubTable;
using Syncfusion.Maui.Data;
using Syncfusion.Maui.Inputs;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class AddRoutesPage : ContentPage
{
	ГражданинAdapter гражданин;
	СотрудникиAdapter сотрудник;
	АвтомобильAdapter автомобиль;
	
	public AddRoutesPage()
	{
		InitializeComponent();
		var list = new TableCollection<Гражданин>(DBQuery.getAllTable("select * from Гражданин"));

        CivilComboBox.ItemsSource = list.ConvertAll(x => new ГражданинAdapter(x.ID,x.ФИО+";"+x.НомерПаспорта)).ToList();
		var list2 = new TableCollection<АвтомобильFilter>(DBQuery.getAllTable("select * from Автомобиль"));

        AutoComboBox.ItemsSource = list2.ConvertAll(x => new АвтомобильAdapter(x.ID, x.Модель + ";" + x.ГосНомер)).ToList();

        var list3 = new TableCollection<СотрудникДолжностьFilter>(DBQuery.getAllTable("select Сотрудники.ID,ФИО,Название from Сотрудники,Должность where ID_Должности=Должность.ID"));

        EmployeeComboBox.ItemsSource = list3.ConvertAll(x => new СотрудникиAdapter(x.ID, x.Фио + ";" + x.НазваниеДолжности)).ToList();
    }
    public async void InsertRow(object sender, EventArgs e)
	{
		if(сотрудник is null || гражданин is null || автомобиль is null)
		{
			await this.DisplayAlert("Ошибка", "Обязательно выберите Гражданина, Автомобиль и Сотрудника", "Закрыть");
			return;
        }
		bool DoThing = await this.DisplayAlert("Вы уверены", "Добавить Запись?", "Да", "Нет");
		if (DoThing)
		{
			DBQuery.ChangeTable($"declare @Temp INT exec @Temp = [dbo].ВернутьДежурствоСотрудника {сотрудник.ID} Insert into Перемещения values (@Temp,{гражданин.ID},{автомобиль.ID},GetDate())");
			
		}

	}
	private void CheckSelectedItem(object sender, EventArgs e)
	{
		if((sender as SfComboBox).SelectedItem is ГражданинAdapter)
		{
			гражданин = (sender as SfComboBox).SelectedItem as ГражданинAdapter;
            CivilList.ItemsSource =  new TableCollection<ГражданинСтраны>(DBQuery.getAllTable($"select * from Гражданин,Страны where Гражданин.ID={гражданин.ID} and ID_Страны=Страны.ID"));
        }
        if ((sender as SfComboBox).SelectedItem is АвтомобильAdapter)
        {
            автомобиль = (sender as SfComboBox).SelectedItem as АвтомобильAdapter;
            AutoList.ItemsSource = new TableCollection<АвтомобильМодель>(DBQuery.getAllTable($"select * from Автомобиль,ВидыТранспорта where Автомобиль.ID={автомобиль.ID} and ID_Вида=ВидыТранспорта.ID"));
        }
        if ((sender as SfComboBox).SelectedItem is СотрудникиAdapter)
        {
            сотрудник = (sender as SfComboBox).SelectedItem as СотрудникиAdapter;

            EmployeeList.ItemsSource = new TableCollection<ДежурныйСотрудник>(DBQuery.getAllTable($"declare @Temp INT exec @Temp = [dbo].ВернутьДежурствоСотрудника {сотрудник.ID} " +
				$"Select Дежурства.ID,ФИО,Дата_Рождения,Название,ДатаВремя_Конца,ДатаВремя_Начала from Дежурства,Сотрудники,Должность where Дежурства.ID=@Temp and Сотрудники.ID=Дежурства.ID_Сотрудника and ID_Должности=Должность.ID"));
        }
    }

    private void TestComboBox_Unfocused(object sender, FocusEventArgs e)
    {
        if ((sender as SfComboBox).SelectedItem is Adapter)
		{
			CheckSelectedItem(sender, e);
			return;
		}
        (sender as SfComboBox).Text= string.Empty;
    }
}