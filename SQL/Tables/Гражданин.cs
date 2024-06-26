﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class Гражданин : ITableExtract<Гражданин>
    {
        public int ID { get; set; }

        public string ФИО { get; set; }
        [DisplayName("Номер Паспорта")]
        public string НомерПаспорта { get; set; }
        [DisplayName("Дата Рождения")]
        public DateTime? ДатаРождения { get; set; }
        [DisplayName("Адрес Проживания")]
        public string? АдресПроживания { get; set; }
        [DisplayName("Страна")]
        public int IdСтраны { get; set; }

        public Гражданин ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            ФИО = Convert.ToString(row["Фио"]);
            НомерПаспорта = Convert.ToString(row["Номер_Паспорта"]);
            ДатаРождения = Convert.ToDateTime(row["Дата_Рождения"]);
            АдресПроживания = Convert.ToString(row["Адрес_Проживания"]);
            IdСтраны = Convert.ToInt32(row["ID_Страны"]);
            return this;
        }
    }
}
