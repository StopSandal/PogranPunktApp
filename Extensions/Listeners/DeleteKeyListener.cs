
using PogranPunktApp.SQL;
using Syncfusion.Maui.Charts;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.Extensions.Listeners
{
    internal abstract class DeleteKeyListener : IKeyboardListener
    {
        protected int ID;
        protected SfDataGrid grid;
        private DeleteKeyListener()
        {

        }
        public DeleteKeyListener(int iD, SfDataGrid grid)
        {
            ID = iD;
            this.grid = grid;
        }

        public void OnKeyDown(KeyEventArgs args)
        {
        }
        public abstract void OnPreviewKeyDown(KeyEventArgs args);

        public void OnKeyUp(KeyEventArgs args)
        {
        }
        public void SetID(int id)
        {
            ID = id;

        }
        public SfDataGrid GetGrid()
        {
            return grid;
        }
        public async Task<bool> OnDeleteAction(string DeleteSource, string ErrorMessage)
        {
            if (ID > 0)
            {
                bool choice = await Application.Current.MainPage.DisplayAlert("Удаление", "Вы точно хотите удалить выбранную запись?", "Да", "Нет");
                if (choice)
                {
                    choice = DBQuery.ChangeTable($"Delete from {DeleteSource} where ID={ID}");
                    if (choice)
                    {
                        await Application.Current.MainPage.DisplayAlert("Удаление", "Запись Успешно Удалена", "Закрыть");
                        return true;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Удаление", "Запись не удалена." + ErrorMessage, "Закрыть");
                    }
                }
            }
            return false;
        }


    }

    
}
