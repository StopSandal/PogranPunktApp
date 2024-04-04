using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables.SubTable
{
    internal class РасширениеАвтомобильМодель : АвтомобильМодель, ITableExtract<РасширениеАвтомобильМодель>
    {
        public РасширениеАвтомобильМодель()
        {

        }
        public РасширениеАвтомобильМодель(РасширениеАвтомобильМодель other) : base(other)
        {
            this.ID = other.ID;
        }
        public int ID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is РасширениеАвтомобильМодель модель &&
                   Модель == модель.Модель &&
                   ГосНомер == модель.ГосНомер &&
                   Цвет == модель.Цвет &&
                   ВидТранспорта == модель.ВидТранспорта &&
                   ID == модель.ID;
        }

        public new РасширениеАвтомобильМодель ParseTableRow(DataRow row)
        {
            base.ParseTableRow(row);
            ID = Convert.ToInt32(row["ID"]);
            return this;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
