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
    class ScheduleDeleteListener : DeleteKeyListener
    {
        public ScheduleDeleteListener(int iD, SfDataGrid grid) : base(iD, grid)
        {
        }
        public async override void OnPreviewKeyDown(KeyEventArgs args)
        {
            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                if (await OnDeleteAction("Дежурства", "Невозможно удалить дежурство, так как у него есть зарегистрированные перемещения"))
                    GetGrid().ItemsSource = new TableCollection<ДежурныйСотрудник>(DBQuery.getAllTable($"Select Дежурства.ID,ФИО,Дата_Рождения,Название,ДатаВремя_Конца,ДатаВремя_Начала,Сотрудники.ID as 'ID_Сотрудника' from Дежурства,Сотрудники,Должность where  Сотрудники.ID=Дежурства.ID_Сотрудника and ID_Должности=Должность.ID"));
            }
        }
    }
}
