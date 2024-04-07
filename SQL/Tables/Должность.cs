using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class Должность : ITableExtract<Должность>
    {
        private int Id;

        public string Название { get; set; } 
        public double Коэффициент { get; set; }

        public Должность ParseTableRow(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            Название = Convert.ToString(row["Название"]);
            Коэффициент = Convert.ToDouble(row["Коэффициент"]);
            return this;
        }
        public Должность()
        {
        }
        public Должность(Должность other)
        {
            this.Id = other.Id;
            this.Название = other.Название;
            this.Коэффициент = other.Коэффициент;
        }

        public override bool Equals(object obj)
        {
            return obj is Должность Должность &&
                   Название == Должность.Название &&
                   Коэффициент == Должность.Коэффициент;
        }
        public override string ToString()
        {
            return $"Название: {Название}, Коэффициент: {Коэффициент}";
        }

        public string ToUpdateSetValuesString()
        {
            return $"Название='{Название}', Коэффициент={Коэффициент.ToString(CultureInfo.GetCultureInfo("en-GB"))}";
        }
        public int getId()
        {
            return Id;
        }
    }
}
