using Microsoft.IdentityModel.Tokens;
using Microsoft.Maui.Animations;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL.Tables.FunctionAdapter;
using PogranPunktApp.SQL.Tables.SubTable;


namespace PogranPunktApp.CustomComponents;

public partial class InsertItemLayout : ContentView
{
    public event EventHandler Completed;
    private CompletedEventArgs completedEventArgs;
    public bool IsValid { get; private set; }

    public InsertItemLayout()
	{
		InitializeComponent();
        TypeCombobox.ItemsSource = new TableCollection<Пошлина>(DBQuery.getAllTable("Select * from Пошлина"));
        NameEntry.ItemsSource = new TableCollection<ТоварыНазвание>(DBQuery.getAllTable("Select Название from Товары"));
        completedEventArgs = new CompletedEventArgs();
	}


    private void OnDoneClicked(object sender, EventArgs e)
    {
        IsValid = !string.IsNullOrEmpty(NameEntry.Text) &&
           !string.IsNullOrEmpty(WeigthEntry.Value?.ToString()) &&
          !string.IsNullOrEmpty(CountEntry.Value?.ToString()) &&
          !string.IsNullOrEmpty(PriceEntry.Value?.ToString()) &&
           !string.IsNullOrEmpty((TypeCombobox.SelectedItem as Пошлина)?.Название);

        if (IsValid)
        {
            DisableEntries();
            DoneButton.IsVisible = false;
            DoneButton.IsEnabled = false;
            completedEventArgs.IsCompleted = true;
            Completed?.Invoke(this, completedEventArgs);
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Заполните товар", "Заполните все поля для добавления товара", "Закрыть");
        }
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        completedEventArgs.IsCanceled = true;
          Completed?.Invoke(this, completedEventArgs);
    }
    private void DisableEntries()
    {
        NameEntry.IsEnabled = false;
        CountEntry.IsEnabled = false;
        PriceEntry.IsEnabled = false;
        WeigthEntry.IsEnabled = false;
        TypeCombobox.IsEnabled = false;
    }
    public ТоварыInsert GetItemData()
    {
        if (!IsValid)
        {
            return null;
        }
        return new ТоварыInsert(
            NameEntry.Text,
            (decimal)WeigthEntry.Value,
            (decimal)PriceEntry.Value,
            (int)CountEntry.Value,
            (TypeCombobox.SelectedItem as Пошлина).ID);
    }
}