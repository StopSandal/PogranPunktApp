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
        TestLabel.Text = "���������� � ����������� ������������������ " + DBQuery.getAllTable($"Select ���� from ����������� where ID={ID}").Rows[0]["����"].ToString();
        Civilian.ItemsSource = new TableCollection<���������������>(DBQuery.getAllTable($"select * from ���������,������ where ���������.ID=(Select ID_���������� from ����������� where ID={ID}) and ID_������=������.ID"));
        Automobile.ItemsSource = new TableCollection<����������������>(DBQuery.getAllTable($"select * from ����������,�������������� where ����������.ID=(Select ID_���������� from ����������� where ID={ID}) and ID_����=��������������.ID"));
        Employee.ItemsSource = new TableCollection<�����������������>(DBQuery.getAllTable($"select * from [dbo].������������������������������({ID})"));
        Goods.ItemsSource = new TableCollection<�������������>(DBQuery.getAllTable($"Select * from �������������������� where ID_�����������={ID}"));

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
       //Select * from ��������������������
    }

    private async void Back(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}