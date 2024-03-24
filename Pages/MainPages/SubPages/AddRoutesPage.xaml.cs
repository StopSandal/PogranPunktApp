using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL.Tables.FunctionAdapter;
using Syncfusion.Maui.Data;
using Syncfusion.Maui.Inputs;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class AddRoutesPage : ContentPage
{
	public AddRoutesPage()
	{
		InitializeComponent();
		var list = new TableCollection<Гражданин>(DBQuery.getAllTable("select * from Гражданин"));

		//AutoList.ItemsSource = list;
		TestComboBox.ItemsSource = list.ConvertAll(x => new ГражданинAdapter(x.ID,x.ФИО+";"+x.НомерПаспорта)).ToList();
    }
    public async void InsertRow(object sender, EventArgs e)
	{
		bool DoThing = await this.DisplayAlert("Вы уверены", "Добавить Запись?", "Да", "Нет");
		if (DoThing)
		{
			DBQuery.ChangeTable($"Insert into Перемещения values (3,3,5,GetDate())");
			
		}

	}
	private void CheckSelectedItem(object sender, EventArgs e)
	{
		if((sender as SfComboBox).SelectedItem is ГражданинAdapter)
		{
            AutoList.ItemsSource = new TableCollection<Гражданин>(DBQuery.getAllTable($"select * from Гражданин where ID={((sender as SfComboBox).SelectedItem as ГражданинAdapter).ID}"));
        }
	}

    private void TestComboBox_Unfocused(object sender, FocusEventArgs e)
    {
        if ((sender as SfComboBox).SelectedItem is ГражданинAdapter)
		{
			CheckSelectedItem(sender, e);
			return;
		}
        (sender as SfComboBox).Text= string.Empty;
		AutoList.ItemsSource = null;
    }
}