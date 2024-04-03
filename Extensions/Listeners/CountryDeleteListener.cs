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
    class CountryDeleteListener : DeleteKeyListener
    {
        public CountryDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                if (await OnDeleteAction("Страны", "Невозможно удалить страну, так как у неё есть зарегистрированные граждане"))
                    GetGrid().ItemsSource =  new TableCollection<Страны>(DBQuery.getAllTable("Select * from Страны"));
            }
        }
    }
}
