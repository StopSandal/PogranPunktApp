using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.FunctionAdapter
{
    class ColumnDiagramAdapter : ITableExtract<ColumnDiagramAdapter>
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public ColumnDiagramAdapter ParseTableRow(DataRow row)
        {
            Name = row["Название"].ToString();
            Count = Convert.ToInt32(row["Count"]);
            return this;
        }
    }
}
