using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL
{
    internal class TableCollection<T> : List<T> where T : class, ITableExtract<T>, new()
    {
        private TableCollection() { }
        public TableCollection(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                Add(new T().ParseTableRow(dr) );
            }
        }
    }
}
