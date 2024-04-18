using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class ГражданинLog : ITableExtract<ГражданинLog>
    {
        public int Id { get; set; }

        public int OldId { get; set; }

        public string Фио { get; set; }

        public string НомерПаспорта { get; set; }

        public DateTime ДатаРождения { get; set; }

        public string АдресПроживания { get; set; } 

        public int IdСтраны { get; set; }
        public string Страна { get; set; }


        public string ConUser { get; set; }

        public string NameHost { get; set; } 

        public DateTime DateOfLog { get; set; }

        public string LogType { get; set; } 

        public ГражданинLog ParseTableRow(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            OldId = Convert.ToInt32(row["OldId"]);
            Фио = Convert.ToString(row["Фио"]);
            НомерПаспорта = Convert.ToString(row["Номер_Паспорта"]);
            ДатаРождения = Convert.ToDateTime(row["Дата_Рождения"]);
            АдресПроживания = Convert.ToString(row["Адрес_Проживания"]);
            IdСтраны = Convert.ToInt32(row["Id_Страны"]);
            Страна = Convert.ToString(row["название"]);
    
            ConUser = Convert.ToString(row["Con_User"]);
            NameHost = Convert.ToString(row["Name_Host"]);
            DateOfLog = Convert.ToDateTime(row["DateOfLog"]);
            LogType = Convert.ToString(row["LogType"]);
            return this;
        }
    }
}
