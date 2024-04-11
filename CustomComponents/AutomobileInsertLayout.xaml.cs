using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.CustomComponents;

public partial class AutomobileInsertLayout : ContentView
{
    public event EventHandler OnInserted;
    public bool IsValid { get; private set; }
    public AutomobileInsertLayout()
	{
		InitializeComponent();
        CountryEntry.ItemsSource = new TableCollection<��������������>(DBQuery.getAllTable("select * from ��������������"));
    }
    private void OpenItemAdding(object sender, EventArgs e)
    {
        AddButton.IsVisible = false;
        AddLayout.IsVisible = true;
    }
    private void OnDoneClicked(object sender, EventArgs e)
    {
        IsValid = !string.IsNullOrEmpty(NameEntry.Text) &&
              !string.IsNullOrEmpty(PassportEntry.Text) &&
              !string.IsNullOrEmpty(AdressEntry.Text) &&
               !string.IsNullOrEmpty((CountryEntry.SelectedItem as ��������������)?.��������);


        if (IsValid)
        {
            InsertItem();
            OnCancelClicked(sender, e);
            OnInserted?.Invoke(this, e);
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("��������� ����������", "��������� ��� ���� ��� ���������� ����������", "�������");
        }
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        AddLayout.IsVisible = false;
        AddButton.IsVisible = true;
        NameEntry.Text = string.Empty;
        PassportEntry.Text = string.Empty;
        AdressEntry.Text = string.Empty;
        CountryEntry.Text = string.Empty;
    }
    private async void InsertItem()
    {
        if (DBQuery.ChangeTable($"Insert into ���������� values ('{NameEntry.Text}','{PassportEntry.Text}','{AdressEntry.Text}',{(CountryEntry.SelectedItem as ��������������).ID})"))
        {
            await Application.Current.MainPage.DisplayAlert("����������", "������ ������� ���������", "�������");
        }
        else
            await Application.Current.MainPage.DisplayAlert("����������", "��������� ������. ���������� � ����� �������� ��� ���������� ��� ��������� ������ �������", "�������");
    }
}