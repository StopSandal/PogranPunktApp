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
            Application.Current.MainPage.DisplayAlert("Заполните Страну", "Заполните все поля для добавления вида транспорта", "Закрыть");
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
        if (DBQuery.ChangeTable($"Insert into ВидыТранспорта values ('{NameEntry.Text}')"))
        {
            await Application.Current.MainPage.DisplayAlert("Добавление", "Запись успешно добавлена", "Закрыть");
        }
        else
            await Application.Current.MainPage.DisplayAlert("Добавление", "Произошла ошибка. Вид транспорта с таким название уже существует или произошла ошибка сервера", "Закрыть");
    }
}