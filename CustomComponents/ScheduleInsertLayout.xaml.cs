using PogranPunktApp.SQL;

namespace PogranPunktApp.CustomComponents;

public partial class ScheduleInsertLayout : ContentView
{
    public event EventHandler OnInserted;
    public bool IsValid { get; private set; }

    public ScheduleInsertLayout()
	{
		InitializeComponent();
        //CountryEntry.ItemsSource = new TableCollection<Должность>(DBQuery.getAllTable("select * from Должность"));
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
            Application.Current.MainPage.DisplayAlert("Заполните Сотрудника", "Заполните все поля для добавления сотрудника", "Закрыть");
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
        if (DBQuery.ChangeTable($"Insert into Дежурства values ('{NameEntry.Text}','{StartDateEntry.Date.ToString("yyyy-MM-dd")}','{EndDateEntry.Date.ToString("yyyy-MM-dd")}')"))
        {
            await Application.Current.MainPage.DisplayAlert("Добавление", "Запись успешно добавлена", "Закрыть");
        }
        else
            await Application.Current.MainPage.DisplayAlert("Добавление", "Произошла ошибка. Дежурство в это время уже существует или продолжительность меньше суток или произошла ошибка сервера", "Закрыть");
    }
}