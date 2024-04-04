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
        public АвтомобильМодель()
        {
        }
        public АвтомобильМодель(АвтомобильМодель other)
        {
            this.Модель = other.Модель;
            this.ГосНомер = other.ГосНомер;
            this.Цвет = other.Цвет;
            this.ВидТранспорта = other.ВидТранспорта;
        }

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

        public override string ToString()
        {

            return $"Модель: {Модель}, " +
                   $"ГосНомер: {ГосНомер}, " +
                   $"Цвет: {Цвет}, " +
                   $"Вид транспорта: {ВидТранспорта}";
        }
        public string ToUpdateSetValuesString()
        {
            return $"Модель='{Модель}', " +
                   $"ГосНомер='{ГосНомер}', " +
                   $"Цвет='{Цвет}', " +
                   $"ID_Вида=(Select ID from ВидыТранспорта where Название='{ВидТранспорта}')";
        }
    }
}
