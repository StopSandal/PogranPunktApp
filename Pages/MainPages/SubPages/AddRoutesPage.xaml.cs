using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL.Tables.FunctionAdapter;
using PogranPunktApp.SQL.Tables.SubTable;
using Syncfusion.Maui.Data;
using Syncfusion.Maui.Inputs;
using System.Text;

namespace PogranPunktApp.Pages.MainPages.SubPages;

public partial class AddRoutesPage : ContentPage
{
	���������Adapter ���������;
	����������Adapter ���������;
	����������Adapter ����������;
	
	public AddRoutesPage()
	{
		InitializeComponent();
		var list = new TableCollection<���������>(DBQuery.getAllTable("select * from ���������"));

        CivilComboBox.ItemsSource = list.ConvertAll(x => new ���������Adapter(x.ID,x.���+";"+x.�������������)).ToList();
		var list2 = new TableCollection<����������Filter>(DBQuery.getAllTable("select * from ����������"));

        AutoComboBox.ItemsSource = list2.ConvertAll(x => new ����������Adapter(x.ID, x.������ + ";" + x.��������)).ToList();

        var list3 = new TableCollection<������������������Filter>(DBQuery.getAllTable("select ����������.ID,���,�������� from ����������,��������� where ID_���������=���������.ID"));

        EmployeeComboBox.ItemsSource = list3.ConvertAll(x => new ����������Adapter(x.ID, x.��� + ";" + x.�����������������)).ToList();
    }
    public async void InsertRow(object sender, EventArgs e)
	{
		if(��������� is null || ��������� is null || ���������� is null)
		{
			await this.DisplayAlert("������", "����������� �������� ����������, ���������� � ����������", "�������");
			return;
        }
        if (!GoodsCollection.IsItemsReadyToInsert())
        {
            await this.DisplayAlert("������", "��������� ���������� ���� ������� ��� �������� �������������", "�������");
            return;
        }

        bool DoThing = await this.DisplayAlert("�� �������", "�������� ������?", "��", "���");
		if (DoThing)
		{
            StringBuilder SqlQuery = new StringBuilder();
            SqlQuery.Append($"declare @Temp INT exec @Temp = [dbo].�������������������������� {���������.ID} Insert into ����������� values (@Temp,{���������.ID},{����������.ID},GetDate()) Set @Temp=SCOPE_IDENTITY()");
            if (GoodsCollection.GetAll������().Any())
            {

                foreach (var item in GoodsCollection.GetAll������())
                {
                    SqlQuery.Append($" insert into ������ {������Insert.GetArgumentsInsertString()}  values ({item.GetInsertString()},@Temp) ");
                } 
            }
           DoThing = DBQuery.ChangeTable(SqlQuery.ToString());
            if(!DoThing)
                await this.DisplayAlert("������", "��������� ���������� ������ �������", "�������");
            else
                await this.DisplayAlert("�����", "����������� ������� ����������������", "�������");

        }

	}
	private void CheckSelectedItem(object sender, EventArgs e)
	{
		if((sender as SfComboBox).SelectedItem is ���������Adapter)
		{
			��������� = (sender as SfComboBox).SelectedItem as ���������Adapter;
            CivilList.ItemsSource =  new TableCollection<���������������>(DBQuery.getAllTable($"select * from ���������,������ where ���������.ID={���������.ID} and ID_������=������.ID"));
        }
        if ((sender as SfComboBox).SelectedItem is ����������Adapter)
        {
            ���������� = (sender as SfComboBox).SelectedItem as ����������Adapter;
            AutoList.ItemsSource = new TableCollection<����������������>(DBQuery.getAllTable($"select * from ����������,�������������� where ����������.ID={����������.ID} and ID_����=��������������.ID"));
        }
        if ((sender as SfComboBox).SelectedItem is ����������Adapter)
        {
            ��������� = (sender as SfComboBox).SelectedItem as ����������Adapter;

            EmployeeList.ItemsSource = new TableCollection<�����������������>(DBQuery.getAllTable($"declare @Temp INT exec @Temp = [dbo].�������������������������� {���������.ID} " +
				$"Select ���������.ID,���,����_��������,��������,���������_�����,���������_������ from ���������,����������,��������� where ���������.ID=@Temp and ����������.ID=���������.ID_���������� and ID_���������=���������.ID"));
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