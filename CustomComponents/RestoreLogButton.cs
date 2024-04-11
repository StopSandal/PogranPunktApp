using PogranPunktApp.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    internal class RestoreLogButton : Button
    {
        public event EventHandler OnRestore;
        public static readonly BindableProperty IDProperty =
            BindableProperty.Create(nameof(ID), typeof(int), typeof(DetailsRoutesButton));

        public int ID
        {
            get { return (int)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }
        public RestoreLogButton()
        {
            Clicked += WatchMoreDetailsAsync;
            BackgroundColor = Colors.Transparent;
            BorderColor = Colors.Transparent;
            Margin = new Thickness(5, 5);
            VerticalOptions = LayoutOptions.EndAndExpand;
            HorizontalOptions = LayoutOptions.End;
            Text = "Отменить";
        }
        private void WatchMoreDetailsAsync(object sender, EventArgs e)
        {
            DBQuery.ChangeTable($"exec dbo.RestoreГражданин {ID}");
            OnRestore?.Invoke(sender,e);
        }
    }
}
