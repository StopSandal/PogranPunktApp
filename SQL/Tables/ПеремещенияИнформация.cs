using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class ПеремещенияИнформация : ITableExtract<ПеремещенияИнформация>
    {
        public int? Id { get; set; }
        public DateTime Дата {  get; set; }

        public string? Фиогражданина { get; set; }

        public string? НомерПаспорта { get; set; }

        public string? Модель { get; set; }

        public string? ГосНомер { get; set; }

        public string? Фиосотрудника { get; set; }

        public string? Должность { get; set; }

        public int? Количество { get; set; }

        public ПеремещенияИнформация ParseTableRow(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            Фиогражданина = Convert.ToString(row["ФИОГражданина"]);
            Модель = Convert.ToString(row["Модель"]);
            ГосНомер = Convert.ToString(row["ГосНомер"]);
            Фиосотрудника = Convert.ToString(row["ФИОСотрудника"]);
            Должность = Convert.ToString(row["Должность"]);
            НомерПаспорта = Convert.ToString(row["НомерПаспорта"]);
            Дата = Convert.ToDateTime(row["Дата"]);
            Количество = Convert.ToInt32(row["Количество"]);
            return this;
        }
    }
}
