using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    class Пошлина : ITableExtract<Пошлина>
    {
        public int ID {  get; set; }
        public string Название { get; set; }
        public decimal Ставка {  get; set; }

        public Пошлина()
        {
        }
        public Пошлина(Пошлина other)
        {
            this.ID = other.ID;
            this.Название = other.Название;
            this.Ставка = other.Ставка;
        }

        public override bool Equals(object obj)
        {
            return obj is Пошлина пошлина &&
                   Название == пошлина.Название &&
                   Ставка == пошлина.Ставка;
        }

        public Пошлина ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Название = Convert.ToString(row["Название"]);
            Ставка = Convert.ToDecimal(row["Ставка"]);
            return this;
        }
        public override string ToString()
        {
            return $"Название: {Название}, Ставка: {Ставка}";
        }

        public string ToUpdateSetValuesString()
        {
            return $"Название='{Название}', Ставка={Ставка.ToString(CultureInfo.GetCultureInfo("en-GB"))}";
        }
    }
}
