using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.SubTable
{
    internal class РасширениеАвтомобильМодель : АвтомобильМодель, ITableExtract<РасширениеАвтомобильМодель>
    {
        public int ID { get; set; }
        public new РасширениеАвтомобильМодель ParseTableRow(DataRow row)
        {
            base.ParseTableRow(row);
            ID = Convert.ToInt32(row["ID"]);
            return this;
        }
    }
}
