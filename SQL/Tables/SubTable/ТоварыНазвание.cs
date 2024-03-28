using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.SubTable
{
    class ТоварыНазвание : ITableExtract<ТоварыНазвание>
    {
        public string Название { get; set; }

        public ТоварыНазвание ParseTableRow(DataRow row)
        {
            Название =  Convert.ToString(row[0]);
            return this;
        }
    }
}
