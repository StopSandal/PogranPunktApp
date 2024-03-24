using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    class ГражданинСтраны : ITableExtract<ГражданинСтраны>
    {

        public string ФИО { get; set; }
        [DisplayName("Номер Паспорта")]
        public string НомерПаспорта { get; set; }
        [DisplayName("Дата Рождения")]
        public DateTime? ДатаРождения { get; set; }
        [DisplayName("Адрес Проживания")]
        public string АдресПроживания { get; set; }
        [DisplayName("Страна")]
        public string Страна { get; set; }
        public ГражданинСтраны ParseTableRow(DataRow row)
        {
            ФИО = Convert.ToString(row["Фио"]);
            НомерПаспорта = Convert.ToString(row["Номер_Паспорта"]);
            ДатаРождения = Convert.ToDateTime(row["Дата_Рождения"]);
            АдресПроживания = Convert.ToString(row["Адрес_Проживания"]);
            Страна = Convert.ToString(row["Название"]);
            return this;
        }
    }
}
