using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.FunctionAdapter
{
    internal class АвтомобильAdapter : Adapter
    {
        public АвтомобильAdapter(int iD, string filteringField) : base(iD, filteringField)
        {
        }
    }
}
