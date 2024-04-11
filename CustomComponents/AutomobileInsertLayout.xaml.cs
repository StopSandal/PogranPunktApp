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
        CountryEntry.ItemsSource = new TableCollection<ВидыТранспорта>(DBQuery.getAllTable("select * from ВидыТранспорта"));
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
               !string.IsNullOrEmpty((CountryEntry.SelectedItem as ВидыТранспорта)?.Название);


        if (IsValid)
        {
            InsertItem();
            OnCancelClicked(sender, e);
            OnInserted?.Invoke(this, e);
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Заполните Автомобиль", "Заполните все поля для добавления автомобиля", "Закрыть");
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
        if (DBQuery.ChangeTable($"Insert into Автомобиль values ('{NameEntry.Text}','{PassportEntry.Text}','{AdressEntry.Text}',{(CountryEntry.SelectedItem as ВидыТранспорта).ID})"))
        {
            await Application.Current.MainPage.DisplayAlert("Добавление", "Запись успешно добавлена", "Закрыть");
        }
        else
            await Application.Current.MainPage.DisplayAlert("Добавление", "Произошла ошибка. Автомобиль с таким номерами уже существует или произошла ошибка сервера", "Закрыть");
    }
}