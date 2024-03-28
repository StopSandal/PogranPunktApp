using Syncfusion.Maui.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.CustomComponents
{
    class BaseNumericEntry : SfNumericEntry
    {
        public BaseNumericEntry() {
            CustomFormat = "N4";
        }
    }
}
