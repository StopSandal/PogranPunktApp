using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    class ДежурныйСотрудник : ITableExtract<ДежурныйСотрудник>
    {
        private int ID;
        [DisplayName("ФИО")]
        public string Фио { get; set; } = null!;
        [DisplayName("ДатаРождения")]
        public DateTime ДатаРождения { get; set; }
        [DisplayName("Начало Дежурства")]
        public DateTime ДатаНачалаДежурства { get; set; }
        [DisplayName("Окончание Дежурства")]
        public DateTime ДатаКонцаДежурства { get; set; }
        [DisplayName("Звание")]
        public string НазваниеДолжности { get; set; }
        private int ID_Сотрудника;

        public ДежурныйСотрудник()
        {
        }

        public ДежурныйСотрудник ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            ID_Сотрудника = Convert.ToInt32(row["ID_Сотрудника"]);
            Фио = Convert.ToString(row["ФИО"]);
            НазваниеДолжности = Convert.ToString(row["Название"]);
            ДатаРождения = Convert.ToDateTime(row["Дата_Рождения"]);
            ДатаНачалаДежурства = Convert.ToDateTime(row["ДатаВремя_Начала"]);
            ДатаКонцаДежурства = Convert.ToDateTime(row["ДатаВремя_Конца"]);
            return this;
        }
        public int GetID()
        {
            return ID;
        }
        public int GetID_Employee()
        {
            return ID_Сотрудника;
        }

        public override bool Equals(object obj)
        {
            return obj is ДежурныйСотрудник сотрудник &&
                   Фио == сотрудник.Фио &&
                   ДатаРождения == сотрудник.ДатаРождения &&
                   ДатаНачалаДежурства == сотрудник.ДатаНачалаДежурства &&
                   ДатаКонцаДежурства == сотрудник.ДатаКонцаДежурства &&
                   НазваниеДолжности == сотрудник.НазваниеДолжности &&
                   ID_Сотрудника == сотрудник.ID_Сотрудника;
        }

        public ДежурныйСотрудник(ДежурныйСотрудник other)
        {
            this.ID = other.ID;
            this.ID_Сотрудника = other.ID_Сотрудника;
            this.Фио = other.Фио;
            this.ДатаРождения = other.ДатаРождения;
            this.ДатаНачалаДежурства = other.ДатаНачалаДежурства;
            this.ДатаКонцаДежурства = other.ДатаКонцаДежурства;
            this.НазваниеДолжности = other.НазваниеДолжности;
        }
        public string ToUpdateSetValuesString()
        {
            return 
                   $"ДатаВремя_Начала='{ДатаНачалаДежурства.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                   $"ДатаВремя_Конца='{ДатаКонцаДежурства.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                   $"ID_Сотрудника={ID_Сотрудника}";
        }
        public override string ToString()
        {
            return $"ФИО: {Фио}, " +
                   $"Дата Рождения: {ДатаРождения.ToString("yyyy-MM-dd")}, " +
                   $"Звание: {НазваниеДолжности}" +
                   $"Начало Дежурства: {ДатаНачалаДежурства.ToString("yyyy-MM-dd HH:mm:ss")}, " +
                   $"Окончание Дежурства: {ДатаКонцаДежурства.ToString("yyyy-MM-dd HH:mm:ss")}" 
                   ;
        }
    }
}
