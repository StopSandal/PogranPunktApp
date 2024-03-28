
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    public partial class ОтделКадровТаблица : ITableExtract<ОтделКадровТаблица>
    {
        private int Id;

        public string Фио { get; set; }
        public DateTime? ДатаРождения { get; set; }

        public DateTime ДатаПоступления { get; set; }

        private int IdДолжности;
        public string НазваниеДолжности { get; set; }

        public string Аккаунт { get; set; }

        public string СменаПароля { get; set; }

        public ОтделКадровТаблица ParseTableRow(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            Фио = Convert.ToString(row["ФИО"]);
            НазваниеДолжности = Convert.ToString(row["Название"]);
            ДатаРождения = Convert.ToDateTime(row["Дата_Рождения"]);
            ДатаПоступления = Convert.ToDateTime(row["Дата_Поступления"]);
            IdДолжности = Convert.ToInt32((int)row["ID_Должности"]);
            Аккаунт = Convert.ToBoolean(row["Аккаунт"]) ? "Да" : "Нет";
            СменаПароля = Convert.ToBoolean(row["Смена_Пароля"]) ? "Да" : "Нет";
            return this;
        }
        public int getID()
        {
            return Id;
        }
        public int getPositionID()
        {
            return IdДолжности;

        }
 
    }

}
