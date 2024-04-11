using PogranPunktApp.SQL;

namespace PogranPunktApp.CustomComponents;

public partial class ScheduleInsertLayout : ContentView
{
    public event EventHandler OnInserted;
    public bool IsValid { get; private set; }

    public ScheduleInsertLayout()
	{
		InitializeComponent();
        //CountryEntry.ItemsSource = new TableCollection<���������>(DBQuery.getAllTable("select * from ���������"));
    }

    private void OpenItemAdding(object sender, EventArgs e)
    {
        AddButton.IsVisible = false;
        AddLayout.IsVisible = true;
    }
    private void OnDoneClicked(object sender, EventArgs e)
    {
        IsValid = !string.IsNullOrEmpty(NameEntry.Text) &&
              (StartDateEntry.Date != DateTime.Today) &&
              (EndDateEntry.Date != DateTime.Today);


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
        StartDateEntry.Date = DateTime.Today;
        EndDateEntry.Date = DateTime.Today;
    }
    private async void InsertItem()
    {
        if (DBQuery.ChangeTable($"Insert into ��������� values ('{NameEntry.Text}','{StartDateEntry.Date.ToString("yyyy-MM-dd")}','{EndDateEntry.Date.ToString("yyyy-MM-dd")}')"))
        {
            await Application.Current.MainPage.DisplayAlert("����������", "������ ������� ���������", "�������");
        }
        else
            await Application.Current.MainPage.DisplayAlert("����������", "��������� ������. ��������� � ��� ����� ��� ���������� ��� ����������������� ������ ����� ��� ��������� ������ �������", "�������");
    }
}