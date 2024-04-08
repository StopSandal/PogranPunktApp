using PogranPunktApp.SQL;
using System.Globalization;

namespace PogranPunktApp.CustomComponents;

public partial class PositionInsertLayout : ContentView
{
    //
    public event EventHandler OnInserted;

    public bool IsValid { get; private set; }
    public PositionInsertLayout()
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
        IsValid = !string.IsNullOrEmpty(NameEntry.Text) &&
                  !string.IsNullOrEmpty(RatioEntry.Value?.ToString());

        if (IsValid)
        {
            InsertItem();
            OnCancelClicked(sender, e);


            OnInserted?.Invoke(this, e);
        }
        else
        {
            Application.Current.MainPage.DisplayAlert("Заполните должность", "Заполните все поля для добавления должности", "Закрыть");
        }
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        AddLayout.IsVisible = false;
        AddButton.IsVisible = true;
        NameEntry.Text = string.Empty;
        RatioEntry.Value = 0.00;
    }
    private async void InsertItem()
    {
        if (DBQuery.ChangeTable($"Insert into Должность values ('{NameEntry.Text}',{((double)RatioEntry.Value).ToString(CultureInfo.GetCultureInfo("en-GB")) })"))
        {
            await Application.Current.MainPage.DisplayAlert("Добавление", "Запись успешно добавлена", "Закрыть");
        }
        else
            await Application.Current.MainPage.DisplayAlert("Добавление", "Произошла ошибка. Должность с таким названием уже существует или произошла ошибка сервера", "Закрыть");
    }

}