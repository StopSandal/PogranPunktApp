using PogranPunktApp.SQL.Tables.View;
using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables;
using PogranPunktApp.Pages.MainPages.SubPages;

namespace PogranPunktApp.Pages.MainPages;

public partial class RoutesPage : ContentPage
{
    //select T1.* from Перемещения cross apply ВсёОПеремещениях(ID) as T1
    public RoutesPage()
	{
		InitializeComponent();
   
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
}