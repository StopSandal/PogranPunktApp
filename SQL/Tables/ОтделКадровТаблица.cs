
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
        public DateTime ДатаРождения { get; set; }

        public DateTime ДатаПоступления { get; set; }

        private int IdДолжности;
        public string НазваниеДолжности { get; set; }

        public string Аккаунт { get; set; }

        public string СменаПароля { get; set; }

        public ОтделКадровТаблица()
        {
        }
        public ОтделКадровТаблица(ОтделКадровТаблица other)
        {
            this.Id = other.Id;
            this.Фио = other.Фио;
            this.ДатаРождения = other.ДатаРождения; 
            this.ДатаПоступления = other.ДатаПоступления;
            this.IdДолжности = other.IdДолжности;
            this.НазваниеДолжности = other.НазваниеДолжности;
            this.Аккаунт = other.Аккаунт;
            this.СменаПароля = other.СменаПароля;
        }
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

        public override bool Equals(object obj)
        {
            return obj is ОтделКадровТаблица таблица &&
                   Фио == таблица.Фио &&
                   ДатаРождения == таблица.ДатаРождения &&
                   ДатаПоступления == таблица.ДатаПоступления &&
                   НазваниеДолжности == таблица.НазваниеДолжности;
        }
        public string ToUpdateSetValuesString()
        {
            return $"ФИО='{Фио}', " +
                   $"Дата_Рождения='{ДатаРождения.ToString("yyyy-MM-dd")}', " + // Handle nullable date
                   $"Дата_Поступления='{ДатаПоступления.ToString("yyyy-MM-dd")}', " +
                   $"ID_Должности={IdДолжности}";
        }
        public override string ToString()
        {
            return $"ID: {Id}, " +
                   $"ФИО: {Фио}, " +
                   $"Дата Рождения: {ДатаРождения.ToString("yyyy-MM-dd")}, " + // Handle nullable date
                   $"Дата Поступления: {ДатаПоступления.ToString("yyyy-MM-dd")}, " +
                   $"Название Должности: {НазваниеДолжности}" ;
        }

    }

}
