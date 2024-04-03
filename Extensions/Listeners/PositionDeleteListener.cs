using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.Extensions.Listeners
{
    class PositionDeleteListener : DeleteKeyListener
    {
        public PositionDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                if (await OnDeleteAction("Должность", "Невозможно удалить должность, так как есть сотрудники с данной должностью"))
                    GetGrid().ItemsSource = new TableCollection<Должность>(DBQuery.getAllTable("Select * from Должность"));
            }
        }
    }
}
