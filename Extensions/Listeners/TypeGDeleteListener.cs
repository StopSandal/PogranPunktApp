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
    class TypeGDeleteListener : DeleteKeyListener
    {
        public TypeGDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                if (await OnDeleteAction("Пошлина", "Невозможно удалить вид товара, так как есть товары с данным видом."))
                    GetGrid().ItemsSource = new TableCollection<Пошлина>(DBQuery.getAllTable("Select * from Пошлина"));
            }
        }
    }
}
