using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.FunctionAdapter
{
    internal class LineDiagramAdapter : ITableExtract<LineDiagramAdapter>
    {
        public DateTime Дата { get; set; }
        public decimal Цена {  get; set; }

        public LineDiagramAdapter ParseTableRow(DataRow row)
        {
            Дата = Convert.ToDateTime(row["Дата"]);
            Цена = Convert.ToDecimal(row["Цена"]);
            return this;
        }
    }
}
