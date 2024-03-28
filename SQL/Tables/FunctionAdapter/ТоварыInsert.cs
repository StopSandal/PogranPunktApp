using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.FunctionAdapter
{
    public class ТоварыInsert
    {
        public string Название { get; set; }

        public decimal Вес { get; set; }

        public decimal Стоимость { get; set; }
        public int Количество { get; set; }
        public int ID_Вида { get; set; }

        public ТоварыInsert(string название, decimal вес, decimal стоимость, int количество, int iD_Вида)
        {
            Название = название;
            Вес = вес;
            Стоимость = стоимость;
            Количество = количество;
            ID_Вида = iD_Вида;
        }
        public string GetInsertString()
        {
            return $"'{Название}',{Вес},{Стоимость},{Количество},{ID_Вида}";
        }
        public static string GetArgumentsInsertString()
        {
            return " (Название,Вес,Стоимость,Количество,ID_Пошлины,ID_Перемещения) ";
        }
    }
}
