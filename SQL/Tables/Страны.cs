using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class Страны : ITableExtract<Страны>
    {
        public int ID { get; set; }

        public string Название { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Страны страны &&
                   ID == страны.ID &&
                   Название == страны.Название;
        }

        public Страны()
        {
        }
        public Страны(Страны other)
        {
            this.ID = other.ID;
            this.Название = other.Название;
        }

        public Страны ParseTableRow(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            Название = Convert.ToString(row["Название"]);
            return this;
        }
        public override string ToString()
        {
            return $"Название: {Название}";
        }

        public string ToUpdateSetValuesString()
        {
            return $"Название='{Название}' ";
        }
    }
}
