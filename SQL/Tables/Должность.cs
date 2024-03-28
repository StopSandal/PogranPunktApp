using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogranPunktApp.SQL.Tables
{
    internal class Должность : ITableExtract<Должность>
    {
        public int Id { get; set; }

        public string Название { get; set; } 
        public double Коэффициент { get; set; }

        public Должность ParseTableRow(DataRow row)
        {
            Id = Convert.ToInt32(row["ID"]);
            Название = Convert.ToString(row["Название"]);
            Коэффициент = Convert.ToDouble(row["Коэффициент"]);
            return this;
        }
    }
}
