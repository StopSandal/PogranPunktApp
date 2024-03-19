using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL
{
    internal interface ITableExtract<T> where T : class,new()
    {
        public T ParseTableRow(DataRow row);

    }
}
