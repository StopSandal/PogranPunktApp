using PogranPunktApp.SQL;

namespace PogranPunktApp.CustomComponents;

public partial class ModelsInsertLayout : ContentView
{
    public event EventHandler OnInserted;

    public bool IsValid { get; private set; }
    public ModelsInsertLayout()
	{
		InitializeComponent();
	}
    private void OpenItemAdding(object sender, EventArgs e)
    {
        AddButton.IsVisible = false;
        AddLayout.IsVisible = true;
    }
    private void OnDoneClicked(object sender, EventArgs e)
    {
        IsValid = !string.IsNullOrEmpty(NameEntry.Text);

        if (IsValid)
        {
            InsertItem();
            OnCancelClicked(sender, e);


            OnInserted?.Invoke(this, e);
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("��������� ������", "��������� ��� ���� ��� ���������� ���� ����������", "�������");
        }
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        AddLayout.IsVisible = false;
        AddButton.IsVisible = true;
        NameEntry.Text = string.Empty;
    }
    private async void InsertItem()
    {
        if (DBQuery.ChangeTable($"Insert into �������������� values ('{NameEntry.Text}')"))
        {
            await Application.Current.MainPage.DisplayAlert("����������", "������ ������� ���������", "�������");
        }
        else
            await Application.Current.MainPage.DisplayAlert("����������", "��������� ������. ��� ���������� � ����� �������� ��� ���������� ��� ��������� ������ �������", "�������");
    }
}