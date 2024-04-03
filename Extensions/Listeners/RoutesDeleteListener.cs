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
    internal class RoutesDeleteListener : DeleteKeyListener
    {
        public RoutesDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                await Application.Current.MainPage.DisplayAlert("Удаление", "Внимание! При удалении перемещения, будут удалены все зарегестрированные при нём товары.", "Закрыть");
                if (await OnDeleteAction("Перемещения", "Невозможно удалить, произошла внутренняя ошибка сервера"))
                    GetGrid().ItemsSource = new TableCollection<ПеремещенияИнформация>(DBQuery.getAllTable("select T1.* from Перемещения cross apply ВсёОПеремещениях(ID) as T1"));
            }
        }
    }
}
