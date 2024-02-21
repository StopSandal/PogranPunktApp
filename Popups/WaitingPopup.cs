
using CommunityToolkit.Maui.Views;
using PogranPunktApp.SQL;

namespace PogranPunktApp.Popups;

public class WaitingPopup : Popup
{
    public WaitingPopup()
    {
        var but = new Button { HorizontalOptions = LayoutOptions.Center, Text = "Отмена", CornerRadius = 5 };
        but.Clicked += (s, e) => { DBInfo.IsTryReconnect = false; DBInfo.AbroadConnection(); };

        Content = new VerticalStackLayout
        {
            HeightRequest = 0,
            BackgroundColor = Colors.Transparent,
            Children = {
                new ActivityIndicator {IsRunning = true, BackgroundColor=Colors.Transparent},
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Установка Соединения",
                BackgroundColor = Colors.Transparent
                },
                but
            }
        };
    }
}