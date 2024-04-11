using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.CustomComponents;

public partial class EmployeeInsertLayout : ContentView
{
    public event EventHandler OnInserted;
    public bool IsValid { get; private set; }
    public EmployeeInsertLayout()
	{
		InitializeComponent();
        CountryEntry.ItemsSource = new TableCollection<���������>(DBQuery.getAllTable("select * from ���������"));
    }
    private void OpenItemAdding(object sender, EventArgs e)
    {
        AddButton.IsVisible = false;
        AddLayout.IsVisible = true;
    }
    private void OnDoneClicked(object sender, EventArgs e)
    {
        IsValid = !string.IsNullOrEmpty(NameEntry.Text) &&
              (TakingEntry.Date != DateTime.Today) &&
               !string.IsNullOrEmpty((CountryEntry.SelectedItem as ���������)?.��������) &&
              (DateEntry.Date != DateTime.Today);


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
        DateEntry.Date = DateTime.Today;
        TakingEntry.Date = DateTime.Today;
        CountryEntry.Text = string.Empty;
    }
    private async void InsertItem()
    {
        if (DBQuery.ChangeTable($"Insert into ���������� values ('{NameEntry.Text}','{DateEntry.Date.ToString("yyyy-MM-dd")}','{TakingEntry.Date.ToString("yyyy-MM-dd")}',{(CountryEntry.SelectedItem as ���������).getId()})"))
        {
            await Application.Current.MainPage.DisplayAlert("����������", "������ ������� ���������", "�������");
        }
        else
            await Application.Current.MainPage.DisplayAlert("����������", "��������� ������. ��������� � ����� ������� ��� ���������� ��� ��������� ������ �������", "�������");
    }
}