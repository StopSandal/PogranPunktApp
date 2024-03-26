using PogranPunktApp.SQL.Tables.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    class ТоварыПошлина : ITableExtract<ТоварыПошлина>
    {
        public string Название { get; set; }

        public decimal Вес { get; set; }

        public decimal Стоимость { get; set; }
        public int Количество { get; set; }
        [DisplayName("Вид товара")]
        public string ВидПошлины { get; set; }
        public ТоварыПошлина ParseTableRow(DataRow row)
        {
            Название = Convert.ToString(row["Название"]);
            Вес = Convert.ToDecimal(row["Вес"]);
            Стоимость = Convert.ToDecimal(row["Стоимость"]);
            Количество = Convert.ToInt32(row["Количество"]);

            ВидПошлины = Convert.ToString(row["ВидПошлины"]);

            return this;
        }
    }
}
