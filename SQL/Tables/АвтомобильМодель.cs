using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    class АвтомобильМодель : ITableExtract<АвтомобильМодель>
    {

        public string Модель { get; set; } = null!;

        public string ГосНомер { get; set; } = null!;

        public string Цвет { get; set; } = null!;
        [DisplayName("Вид транспорта")]
        public string ВидТранспорта { get; set; } = null!;

        public АвтомобильМодель ParseTableRow(DataRow row)
        {
            Модель = Convert.ToString(row["Модель"]);
            ГосНомер = Convert.ToString(row["ГосНомер"]);
            Цвет = Convert.ToString(row["Цвет"]);
            ВидТранспорта = Convert.ToString(row["Название"]);
            return this;
        }
    }
}
