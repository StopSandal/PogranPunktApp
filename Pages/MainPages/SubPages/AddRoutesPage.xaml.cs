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
		var list = new TableCollection<���������>(DBQuery.getAllTable("select * from ���������"));

		//AutoList.ItemsSource = list;
		TestComboBox.ItemsSource = list.ConvertAll(x => new ���������Adapter(x.ID,x.���+";"+x.�������������)).ToList();
    }
    public async void InsertRow(object sender, EventArgs e)
	{
		bool DoThing = await this.DisplayAlert("�� �������", "�������� ������?", "��", "���");
		if (DoThing)
		{
			DBQuery.ChangeTable($"Insert into ����������� values (3,3,5,GetDate())");
			
		}

	}
	private void CheckSelectedItem(object sender, EventArgs e)
	{
		if((sender as SfComboBox).SelectedItem is ���������Adapter)
		{
            AutoList.ItemsSource = new TableCollection<���������>(DBQuery.getAllTable($"select * from ��������� where ID={((sender as SfComboBox).SelectedItem as ���������Adapter).ID}"));
        }
	}

    private void TestComboBox_Unfocused(object sender, FocusEventArgs e)
    {
        if ((sender as SfComboBox).SelectedItem is ���������Adapter)
		{
			CheckSelectedItem(sender, e);
			return;
		}
        (sender as SfComboBox).Text= string.Empty;
		AutoList.ItemsSource = null;
    }
}