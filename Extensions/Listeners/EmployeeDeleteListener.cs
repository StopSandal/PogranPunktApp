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
    class EmployeeDeleteListener : DeleteKeyListener
    {
        public EmployeeDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                if (await OnDeleteAction("Сотрудники", "Невозможно удалить сотрудника, так как у него есть зарегистрированные перемещения"))
                    GetGrid().ItemsSource = new TableCollection<ОтделКадровТаблица>(DBQuery.getAllTable("select * from ОтделКадровТаблица"));
            }
        }
    }
}
