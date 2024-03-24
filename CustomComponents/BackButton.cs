using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    internal class BackButton : Button
    {
        public BackButton() : base() {
            Clicked += Back;
            BorderWidth = 1;
            BorderColor = Colors.Black;
            Margin = new Thickness(20,20); 
            FontSize = 24;// set Large
            VerticalOptions = LayoutOptions.EndAndExpand;
            HorizontalOptions = LayoutOptions.End;
            Text = "Назад";
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
