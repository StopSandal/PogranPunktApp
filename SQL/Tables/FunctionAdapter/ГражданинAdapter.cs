using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.FunctionAdapter
{
    internal class ГражданинAdapter
    {
        public int ID { get; set; }

        public string FilteringField { get; set; }

        public ГражданинAdapter(int iD, string filteringField)
        {
            ID = iD;
            FilteringField = filteringField;
        }
    }
}
