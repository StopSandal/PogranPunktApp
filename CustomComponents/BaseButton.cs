using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    public class BaseButton : Button
    {
        public BaseButton() : base() {

            BorderWidth = 1;
            BorderColor = Colors.Black;
            Margin = new Thickness(20, 20);
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));// set Large

            Text = "Button";
        }
    }
}
