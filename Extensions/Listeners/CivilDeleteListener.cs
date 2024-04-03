using PogranPunktApp.SQL.Tables.SubTable;
using PogranPunktApp.SQL;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PogranPunktApp.SQL.Tables;

namespace PogranPunktApp.Extensions.Listeners
{
    internal class CivilDeleteListener : DeleteKeyListener
    {
        public CivilDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }

        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                if (await OnDeleteAction("Гражданин","Невозможно удалить гражданина, так как у него есть зарегистрированные перемещения"))
                    GetGrid().ItemsSource = new TableCollection<ГражданинСтраны>(DBQuery.getAllTable("select Гражданин.*, Название from Гражданин, Страны where ID_Страны=Страны.ID"));
            }
        }

    

    }
}
