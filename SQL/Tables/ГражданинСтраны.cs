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
        public ГражданинСтраны()
        {

        }
        public ГражданинСтраны(ГражданинСтраны civilian)
        {
            ID = civilian.ID;
            ФИО = civilian.ФИО;
            НомерПаспорта = civilian.НомерПаспорта;
            ДатаРождения = civilian.ДатаРождения;
            АдресПроживания = civilian.АдресПроживания;
            Страна = civilian.Страна;
        } 
        private int ID;
        public string ФИО { get; set; }
        [DisplayName("Номер Паспорта")]
        public string НомерПаспорта { get; set; }
        [DisplayName("Дата Рождения")]
        public DateTime ДатаРождения { get; set; }
        [DisplayName("Адрес Проживания")]
        public string АдресПроживания { get; set; }
        [DisplayName("Страна")]
        public string Страна { get; set; }
        public ГражданинСтраны ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            ФИО = Convert.ToString(row["Фио"]);
            НомерПаспорта = Convert.ToString(row["Номер_Паспорта"]);
            ДатаРождения = Convert.ToDateTime(row["Дата_Рождения"]);
            АдресПроживания = Convert.ToString(row["Адрес_Проживания"]);
            Страна = Convert.ToString(row["Название"]);
            return this;
        }
        public int GetID()
        {
            return ID;
        }

        public override bool Equals(object obj)
        {
            return obj is ГражданинСтраны страны &&
                   ID == страны.ID &&
                   ФИО == страны.ФИО &&
                   НомерПаспорта == страны.НомерПаспорта &&
                   ДатаРождения == страны.ДатаРождения &&
                   АдресПроживания == страны.АдресПроживания &&
                   Страна == страны.Страна;
        }
        public static bool operator ==(ГражданинСтраны obj1,object obj2) {
            if (obj1 is null || obj2 is null) { return false; }
            return obj1.Equals(obj2);
        }
        public static bool operator !=(ГражданинСтраны obj1, object obj2)
        {
            if (obj1 is null || obj2 is null) { return false; }
            return !obj1.Equals(obj2);
        }

        public override string ToString()
        {
            return $"ФИО: {ФИО}, " +
                   $"Номер Паспорта: {НомерПаспорта}, " +
                   $"Дата Рождения: {ДатаРождения}, " +
                   $"Адрес Проживания: {АдресПроживания}, " +
                   $"Страна: {Страна}";
        }
        public string ToUpdateSetValuesString()
        {
            return $"ФИО='{ФИО}', " +
                   $"Номер_Паспорта='{НомерПаспорта}', " +
                   $"Дата_Рождения='{ДатаРождения.ToString("yyyy-MM-dd hh:mm:ss")}', " +
                   $"Адрес_Проживания='{АдресПроживания}', " +
                   $"ID_Страны=(Select ID from Страны where Название='{Страна}') ";
        }
    }    
}
