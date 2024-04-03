using PogranPunktApp.SQL.Tables.View;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.Pages.MainPages.SubPages;
using PogranPunktApp.Extensions.Listeners;
using Syncfusion.Maui.Core.Internals;

namespace PogranPunktApp.Pages.MainPages;

public partial class RoutesPage : ContentPage
{
    RoutesDeleteListener listener;
    //select T1.* from Перемещения cross apply ВсёОПеремещениях(ID) as T1
    public RoutesPage()
    {
		InitializeComponent();
        dataGrid.ClearKeyboardListeners();
        listener = new RoutesDeleteListener(-1, dataGrid);
        dataGrid.AddKeyboardListener(listener);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.dataGrid.ItemsSource = new TableCollection<ПеремещенияИнформация>(DBQuery.getAllTable("select T1.* from Перемещения cross apply ВсёОПеремещениях(ID) as T1"));

    }

    private async void AddRoute(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoutesPage());
    }
    private void SelectedRow(object sender, EventArgs e)
    {
        if (dataGrid.SelectedRow != null && dataGrid.SelectedIndex > 0)
        {
            listener.SetID((dataGrid.SelectedRow as ПеремещенияИнформация).Id.Value);
        }
    }
}