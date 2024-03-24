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
        public ДежурныйСотрудник ParseTableRow(DataRow row)
        {
            Фио = Convert.ToString(row["ФИО"]);
            НазваниеДолжности = Convert.ToString(row["Название"]);
            ДатаРождения = Convert.ToDateTime(row["Дата_Рождения"]);
            ДатаНачалаДежурства = Convert.ToDateTime(row["ДатаВремя_Начала"]);
            ДатаКонцаДежурства = Convert.ToDateTime(row["ДатаВремя_Конца"]);
            return this;
        }
    }
}
