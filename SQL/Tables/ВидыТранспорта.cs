using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class ВидыТранспорта : ITableExtract<ВидыТранспорта>    
    {
        public int ID { get; set; }

        public string Название { get; set; } = null!;

        public ВидыТранспорта()
        {
        }

        public ВидыТранспорта ParseTableRow(DataRow row)
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

        public override bool Equals(object obj)
        {
            return obj is ВидыТранспорта транспорта &&
                   ID == транспорта.ID &&
                   Название == транспорта.Название;
        }

        public ВидыТранспорта(ВидыТранспорта other)
        {
            this.ID = other.ID;
            this.Название = other.Название;
        }

    }
}
