using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.DataGrid
{
    internal class DataGrid : Grid
    {
        DataTable dataTable;
        public DataGrid(DataTable dataTable) {
            this.dataTable = dataTable;
            fillTable();
        }
        private void setColumns(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        private void fillTable()
        {
            if(dataTable is not null)
            {
                //setColumns(dataTable.Columns.Count);
                setColumns(2);
                this.RowDefinitions.Add(new RowDefinition());
                this.SetRow(new StackLayout()
                {
                    Children =
                    {
                        new Label{Text = "First ROw" },
                        new Label{Text = "Second column"}
                    }
                },0);
            }
        }
    }
}
