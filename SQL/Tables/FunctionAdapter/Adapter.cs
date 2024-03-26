using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.FunctionAdapter
{
    internal abstract class Adapter
    {
        public int ID { get; set; }

        public string FilteringField { get; set; }

        public Adapter(int iD, string filteringField)
        {
            ID = iD;
            FilteringField = filteringField;
        }
    }
}
