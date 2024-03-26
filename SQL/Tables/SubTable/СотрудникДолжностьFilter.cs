using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.SubTable
{
    internal class СотрудникДолжностьFilter : ITableExtract<СотрудникДолжностьFilter>
    {
        public int ID { get; set; }
        public string Фио { get; set; }
        public string НазваниеДолжности { get; set; }

        public СотрудникДолжностьFilter ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Фио = Convert.ToString(row["ФИО"]);
            НазваниеДолжности = Convert.ToString(row["Название"]);
            return this;
        }
    }
}
