using PogranPunktApp.CustomComponents.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    public class GraphicSelectorButton : Button
    {
        public DateFilterEnum DateFilter { get; set; }
        private bool IsSelected = false;
        public GraphicSelectorButton() : base() {
            Padding = new Thickness(2);
            Margin = new Thickness(0);
            BorderColor = Colors.Black;
            Pressed += SetPressedState;
            BackgroundColor = Colors.White;
            CornerRadius = 0;

        }
        private void SetPressedState(object sender, EventArgs e)
        {
            

            if (IsSelected)
            {
                BackgroundColor = Colors.White;
            }
            else
            {
                BackgroundColor = Colors.LightGray;
            }
            IsSelected = !IsSelected;
        }
        public void UnselectButton()
        {
            IsSelected = true;
            SetPressedState(this, EventArgs.Empty);
        }
        public void SelectButton()
        {
            IsSelected = false;
            SetPressedState(this, EventArgs.Empty);
        }
    }
}
