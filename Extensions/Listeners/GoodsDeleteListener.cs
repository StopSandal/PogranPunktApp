using PogranPunktApp.SQL.Tables;
using PogranPunktApp.SQL;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PogranPunktApp.SQL.Tables.View;

namespace PogranPunktApp.Extensions.Listeners
{
    class GoodsDeleteListener : DeleteKeyListener
    {
        public GoodsDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;

                if (await OnDeleteAction("Товары", "Произошла ошибка сервера. Попробуйте позже"))
                    GetGrid().ItemsSource = new TableCollection<ТоварыТаблица>(DBQuery.getAllTable("Select * from ТоварыПоПеремещениям order by Дата Desc"));
            }
        }
    }
}
