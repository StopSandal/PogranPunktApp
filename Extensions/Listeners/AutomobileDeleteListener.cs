using PogranPunktApp.SQL;
using PogranPunktApp.SQL.Tables.SubTable;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.Extensions.Listeners
{
    internal class AutomobileDeleteListener : IKeyboardListener
    {
        private int ID;
        private bool IsSpinLocked = false;
        private bool Result = false;
        private SfDataGrid Grid;

        public AutomobileDeleteListener(int id,SfDataGrid grid)
        {
            ID = id;
            Grid = grid;
        }

        public void SetID(int id)
        {
            ID = id;

        }

        public void OnKeyDown(KeyEventArgs args)
        {
        }
        public async void OnPreviewKeyDown(KeyEventArgs args)
        {


            if (args.Key == KeyboardKey.Delete)
            {
                args.Handled = true;
                if(await OnDeleteAction())
                    Grid.ItemsSource = new TableCollection<РасширениеАвтомобильМодель>(DBQuery.getAllTable($"select * from Автомобиль,ВидыТранспорта where ID_Вида=ВидыТранспорта.ID"));

            }


        }

        public void OnKeyUp(KeyEventArgs args)
        {
        }


        public async Task<bool> OnDeleteAction()
        {

            if (ID > 0)
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("Удаление", "Вы точно хотите удалить выбранную запись?", "Да", "Нет");
                if (choice)
                {
                    choice = DBQuery.ChangeTable($"Delete from Автомобиль where ID={ID}");
                    if (choice)
                    {
                        await Application.Current.MainPage.DisplayAlert("Удаление", "Запись Успешно Удалена", "Закрыть");
                        return true;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Удаление", "Запись НЕ удалена. Невозможно удалить автомобиль, так как на него есть зарегистрированные перемещения", "Закрыть");
                    }
                }
            }
            return false;
        }
    }
}
