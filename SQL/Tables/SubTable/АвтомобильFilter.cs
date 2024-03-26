using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.SubTable
{
    internal class АвтомобильFilter : ITableExtract<АвтомобильFilter>
    {
        public string Модель { get; set; } = null!;

        public string ГосНомер { get; set; } = null!;

        public int ID { get; set; }
        public new АвтомобильFilter ParseTableRow(DataRow row)
        {
            Модель = Convert.ToString(row["Модель"]);
            ГосНомер = Convert.ToString(row["ГосНомер"]);
            ID = Convert.ToInt32(row["ID"]);
            return this;
        }

    }
}
