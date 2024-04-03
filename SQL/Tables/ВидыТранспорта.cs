using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class ВидыТранспорта : ITableExtract<ВидыТранспорта>    
    {
        public int ID { get; set; }

        public string Название { get; set; } = null!;

        public ВидыТранспорта ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Название = Convert.ToString(row["Название"]);
            return this;
        }
    }
}
