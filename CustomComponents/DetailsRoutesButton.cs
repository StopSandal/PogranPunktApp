using PogranPunktApp.Pages.MainPages.SubPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    public class DetailsRoutesButton : Button
    {
        public static readonly BindableProperty IDProperty =
            BindableProperty.Create(nameof(ID), typeof(int), typeof(DetailsRoutesButton));

        public int ID
        {
            get { return (int)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }
        public DetailsRoutesButton() :base(){
            Clicked += WatchMoreDetailsAsync;
            BorderWidth = 1;
            BorderColor = Colors.Black;
            Margin = new Thickness(5, 5);

            FontSize = 24;// set Large
            VerticalOptions = LayoutOptions.EndAndExpand;
            HorizontalOptions = LayoutOptions.End;
            Text = "Подробнее";
        }
        private async void WatchMoreDetailsAsync(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new MoreInfoPage(ID));
        }
    }
}
